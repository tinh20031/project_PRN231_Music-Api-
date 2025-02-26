using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_music.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual ICollection<User_Likes> User_Likes { get; set; } = new List<User_Likes>();
        public virtual ICollection<Streaming_History> Streaming_History { get; set; } = new List<Streaming_History>();
        public virtual ICollection<Favorite_Playlist> Favorite_Playlist { get; } = new List<Favorite_Playlist>();
        public virtual ICollection<User_RecentlyPlayed> User_RecentlyPlayeds { get; set; } = new List<User_RecentlyPlayed>();



    }
}
