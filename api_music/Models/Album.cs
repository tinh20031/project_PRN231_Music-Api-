using System.ComponentModel.DataAnnotations;

namespace api_music.Models
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string ArtistID { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();    

 public virtual Artist Artist { get; set; }

    }
}
