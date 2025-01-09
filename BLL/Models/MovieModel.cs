using BLL.DAL;
using System.ComponentModel;
namespace BLL.Models
{
    public class MovieModel
    {
        public Movie Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Realase Date")]
        public string RealaseDate => !Record.RealaseDate.HasValue ? string.Empty : Record.RealaseDate.Value.ToString("MM/dd/yyyy");

        public string TotalRevenue => Record.TotalRevenue.HasValue ? Record.TotalRevenue.Value.ToString("N2") : "0";

        //name+surname
        public string Director => $"{Record.Director?.Name} {Record.Director?.Surname}";

        //Way 1:
        //[DisplayName ("Genres")]
        //public List<Genre> GenreList => Record.MovieGenres?.Select(mg => mg.Genre).ToList();

        //Way 2:
        public string Genres => string.Join("<br>", Record.MovieGenres?.Select(mg => mg.Genre?.Name) ?? new List<string>());

        [DisplayName("Genres")]
        public List<int> GenreIds
        {
            get => Record.MovieGenres?.Select(mg => mg.GenreId).ToList() ?? new List<int>();
            set => Record.MovieGenres = value?.Select(v => new MovieGenre() { GenreId = v }).ToList();
        }
    }
}
