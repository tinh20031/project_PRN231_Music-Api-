namespace api_music.Models
{
    public class Favorite_Playlist
    {
        public int UserID { get; set; }
        public int PlaylistID { get; set; }
        public DateTime FavoritedAt { get; set; }
        public virtual User User { get; set; }  
        public virtual Playlist Playlist { get; set; }

    }
}
