using System.ComponentModel.DataAnnotations;

namespace api_music.Models
{
    public class Artist
    {
        [Key]
        public string ArtistID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string SpotifyURL { get; set; }

       
        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
        public virtual ICollection<Artist_Song> Artist_Songs { get; set; } = new List<Artist_Song>();


    }
}
