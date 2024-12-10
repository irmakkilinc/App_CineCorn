using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class DirectorModel
    {
        public Director Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;

    }
}
