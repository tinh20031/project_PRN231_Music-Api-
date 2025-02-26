using System.ComponentModel.DataAnnotations;

namespace api_music.Models
{
    public class Artist_Song
    {
        [Key]
       public string  ArtistID { get; set; }
        public int SongID { get; set; }
        
        // many many 
        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }

    }
}
