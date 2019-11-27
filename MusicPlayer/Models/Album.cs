using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class Album
    {
        [Key]
        public Guid AlbumID { get; set; }
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string CoverArt { get; set; }

        [ForeignKey("Artist")]
        public Guid ArtistID { get; set; }
        public virtual Artist Artist { get; set; }

    }
}
