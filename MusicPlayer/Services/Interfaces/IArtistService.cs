using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Services.Interfaces
{
    public interface IArtistService
    {
        List<Models.Artist> Get();
    }
}
