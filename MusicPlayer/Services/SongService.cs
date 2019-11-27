using Microsoft.EntityFrameworkCore;
using MusicPlayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Services
{
    public class SongService : ISongService
    {
        private readonly DBEntities _Context;

        public SongService(DBEntities context)
        {
            _Context = context;
        }

        public List<Models.Song> Get()
        {
            return _Context.Songs.ToList();
        }

        public Models.Song GetById(Guid id)
        {
            return _Context.Songs.FirstOrDefault(o => o.SongID == id);
        }

        public Models.Song Create(Models.Song model)
        {
            _Context.Songs.Add(model);
            _Context.SaveChanges();
            return model;
        }

        public Models.Song Update(Models.Song model)
        {
            _Context.Songs.Attach(model);
            _Context.Entry(model).State = EntityState.Modified;
            _Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var song = GetById(id);
            song.IsDeleted = true;
            Update(song);
        }
    }
}