﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPlayer.Services.Interfaces;

namespace MusicPlayer.Controllers
{

    public class SongController : Controller
    {
        private readonly ISongService _SongService;
        private readonly IArtistService _ArtistService;


        public SongController(ISongService songService, IArtistService artistService)
        {
            _SongService = songService;
            _ArtistService = artistService;
        }
        public IActionResult Get()
        {
            var song = _SongService.Get();
            return View(song);
        }

        public IActionResult Create()
        {
            ViewBag.ArtistsViewBag = _ArtistService.Get().Select(r => new SelectListItem
            {
                Text = r.FirstName,
                Value = r.ArtistID.ToString(),
            }).OrderBy(x => x.Text).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Song model)
        {
            if (ModelState.IsValid)
            {

                if(model.ArtistID == null)
                {
                    Models.Artist artist = new Models.Artist
                    {
                        FirstName = model.Artist.FirstName,
                        LastName = model.Artist.LastName

                    };

                    _ArtistService.Create(artist);
                }
                _SongService.Create(model);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}