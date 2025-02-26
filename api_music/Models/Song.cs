using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api_music.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        public string Title { get; set; }
       
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
 
        public int AlbumId { get; set; }
        public int GenreID { get; set; }
        [StringLength(255)]
        public string SpotifyURL { get; set; }
        [StringLength(255)]
        public string ImageURL { get; set; }

        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Artist_Song> Artist_Songs { get; set; } = new List<Artist_Song>();
        public virtual ICollection<Playlist_Song> Playlists_Songs { get; set; } = new List<Playlist_Song>();
        public virtual ICollection<User_Likes> User_Likes { get; set; } = new List<User_Likes>();
        public virtual ICollection<Streaming_History> Streaming_History { get; set; } = new List<Streaming_History>();
        public virtual ICollection<User_RecentlyPlayed> User_RecentlyPlayed { get; set; } = new List<User_RecentlyPlayed>();

    }
}
