using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public class GenreService : ServiceBase, IService<Genre, GenreModel>
    {
        public GenreService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Genre record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GenreModel> Query()
        {
            return _db.Genres.OrderBy(g  => g.Name).Select(g => new GenreModel() { Record = g });
        }

        public ServiceBase Update(Genre record)
        {
            throw new NotImplementedException();
        }
    }
}
