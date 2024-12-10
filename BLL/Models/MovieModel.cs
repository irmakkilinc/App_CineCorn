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

        public string Director => Record.Director?.Name;  


    }
}
