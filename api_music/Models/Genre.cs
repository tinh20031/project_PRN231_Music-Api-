using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace api_music.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }
        [NotNull ]
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>(); 


    }
}
