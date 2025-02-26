namespace api_music.Models
{
    public class Playlist_Song
    {
        public int PlaylistID { get; set; }
        public int SongID { get; set; }
        public DateTime AddedAt { get; set; }
        // many many 
        public virtual Playlist Playlist { get; set; }
        public virtual Song Song { get; set; }  


    }
}
