using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace api_music.Models
{
    public class Streaming_History
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int HistoryID { get; set; }
        [NotNull]
        public int UserID { get; set; }
        [NotNull]
        public int  SongID { get; set; }
        public virtual User User { get; set; }
        public virtual Song Song { get; set; }


    }
}
