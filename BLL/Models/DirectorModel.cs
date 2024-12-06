using BLL.DAL;

namespace BLL.Models
{
    public class DirectorModel
    {
        public Director Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
    }
}
