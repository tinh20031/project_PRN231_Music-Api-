namespace api_music.Models
{
    public class User_Likes
    {
        public int User_ID { get; set; }
        public int Song_ID { get; set; }
        public DateTime LikeAt { get; set; }
        public virtual User User { get; set; }
        public virtual Song Song { get; set; } 

    }
}
