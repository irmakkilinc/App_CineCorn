using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IDirectorService
    {
        public IQueryable<DirectorModel> Query();

        public ServiceBase Create(Director record);
        public ServiceBase Update(Director record);
        public ServiceBase Delete(int id);

    }
    public class DirectorService : ServiceBase, IDirectorService
    {
        public DirectorService(Db db) : base(db)
        {
        }
        public IQueryable<DirectorModel> Query()
        {
           return _db.Directors.OrderBy(d => d.Name).Select(d => new DirectorModel() { Record = d });
        }
        public ServiceBase Create(Director record)
        {
            if (_db.Directors.Any(d => d.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Director with the same name exists!");
            record.Name = record.Name?.Trim();
            record.Surname = record.Surname?.Trim();
            _db.Directors.Add(record);
            _db.SaveChanges();
            return Success("Director created successfully.");
        }

        public ServiceBase Update(Director record)
        {
            if (_db.Directors.Any(d => d.Id != record.Id && d.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Director with the same exists!");
            var entity = _db.Directors.SingleOrDefault(d => d.Id == record.Id);
            if (entity is null)
                return Error("Species can not be found!");
            entity.Name = record.Name?.Trim();
            entity.Surname = record.Name?.Trim();
            _db.Directors.Update(entity);
            _db.SaveChanges();
            return Success("Director updated successfully.");
        }
        
        public ServiceBase Delete(int id)
        {
            var entity = _db.Directors.Include(d => d.Movies).SingleOrDefault(d => d.Id == id);
            if (entity is null)
                return Error("Director can not be found!");
            if (entity.Movies.Any())
                return Error("Director has relational movie.");
            _db.Directors.Remove(entity);
            _db.SaveChanges();
            return Success("Director deleted successfully.");
        }
    }
}
