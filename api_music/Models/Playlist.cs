using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_music.Models
{
    public class Playlist
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int PlaylistID { get; set; }
        public string Name {  get; set; }
        public int UserID { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool IsPublic { get; set; }
       
        public virtual User User { get; set; }
        public virtual ICollection<Playlist_Song> Playlist_Songs { get; set; } = new List<Playlist_Song>();
        public virtual ICollection<Favorite_Playlist> Favorite_Playlists { get; set; } = new List<Favorite_Playlist>(); 


    }
}
