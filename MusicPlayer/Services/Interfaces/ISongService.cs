using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Services.Interfaces
{
    public interface ISongService
    {
        List<Models.Song> Get();
        Models.Song GetById(Guid id);
        Models.Song Create(Models.Song model);
        Models.Song Update(Models.Song model);
        void Delete(Guid id);
    }
}
