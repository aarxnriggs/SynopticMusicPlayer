using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Models.DTO
{
    public class Song
    {
        [Key]
        public Guid SongID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Album")]
        public Guid? AlbumID { get; set; }

        public SelectList Artists { get; set; }

        public Guid ArtistID { get; set; }

        [ForeignKey("Playlist")]
        public Guid PlaylistID { get; set; }




    }
}
