using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    //Way1:
    //public interface IMovieService
    //{
    //    public IQueryable<MovieModel> Query();
    //    public ServiceBase Create(Movie record);
    //    public ServiceBase Update(Movie record);
    //    public ServiceBase Delete(int id);
    //}

    // public class MovieService : ServiceBase, IMovieService
    public class MovieService : ServiceBase, IService<Movie, MovieModel>
    {
        public MovieService(Db db) : base(db)
        {
        }
        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.Include(m => m.Director).OrderByDescending(m => m.RealaseDate).ThenBy(m => m.Name).
                Select(m => new MovieModel() { Record = m});
        }
        public ServiceBase Create(Movie record)
        {
            if (_db.Movies.Any(m => m.Name.ToLower() == record.Name.ToLower().Trim() && m.RealaseDate == record.RealaseDate))
                return Error("Movie with the same name and realase date exists!");
            record.Name = record.Name?.Trim();
            _db.Add(record);
            _db.SaveChanges();
            return Success("Movie created successfully.");
        }
        public ServiceBase Update(Movie record)
        {
            if (_db.Movies.Any(m => m.Id != record.Id && m.Name.ToLower() == record.Name.ToLower().Trim() && m.RealaseDate == record.RealaseDate))
                return Error("Movie with the same name and realase date exists!");
            record.Name = record.Name?.Trim();
            _db.Update(record);
            _db.SaveChanges();
            return Success("Movie updated successfully.");
        }
        public ServiceBase Delete(int id)
        {
            var entity = _db.Movies.Include(m => m.MovieGenres).SingleOrDefault(m => m.Id == id);
            if (entity is null)
                return Error("Movie cannot be found!");
            _db.MovieGenres.RemoveRange(entity.MovieGenres);
            _db.Movies.Remove(entity);
            _db.SaveChanges();
            return Success("Movie deleted successfully.");
        }

       
    }
}
