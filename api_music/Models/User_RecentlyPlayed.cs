namespace api_music.Models
{
    public class User_RecentlyPlayed
    {

        public int UserID { get; set; }
        public int SongID { get; set; }
        public DateTime PlayedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Song Song { get; set; }

    }
}
