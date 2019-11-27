using Microsoft.EntityFrameworkCore;
using MusicPlayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public class ArtistService : IArtistService
    {
        private readonly DBEntities _Context;

        public ArtistService(DBEntities context)
        {
            _Context = context;
        }

        public List<Models.Artist> Get()
        {
            return _Context.Artists.ToList();
        }

        //public Models.Song GetById(Guid id)
        //{
        //    return _Context.Songs.FirstOrDefault(o => o.SongID == id);
        //}

        public Models.Artist Create(Models.Artist model)
        {
            _Context.Artists.Add(model);
            _Context.SaveChanges();
            return model;
        }

        //public Models.Song Update(Models.Song model)
        //{
        //    _Context.Songs.Attach(model);
        //    _Context.Entry(model).State = EntityState.Modified;
        //    _Context.SaveChanges();
        //    return model;
        //}

        //public void Delete(Guid id)
        //{
        //    var song = GetById(id);
        //    song.IsDeleted = true;
        //    Update(song);
        //}
    }
}