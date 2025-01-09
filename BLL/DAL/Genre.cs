using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        //[Required]
        //[StringLength(70)]
        //public string Name2 { get; set; }

        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}