using Microsoft.EntityFrameworkCore;
using UniBet.Application.Interfaces;

namespace UniBet.Infrastructure.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly AppDbContext _db;

    public BaseRepository(AppDbContext context)
    {
      _db = context;
    }

    public List<T> GetAll()
    {
      return _db.Set<T>().ToList();
    }

    public T? GetById(Guid id)
    {
      return _db.Set<T>().Find(id);
    }

    public T Create(T entity)
    {
      T created = _db.Set<T>().Add(entity).Entity;
      _db.SaveChanges();
      return created;
    }

    public void Update(T entity)
    {
      _db.Set<T>().Update(entity);
      _db.SaveChanges();
    }

    public void Delete(T entity)
    {
      _db.Set<T>().Remove(entity);
      _db.SaveChanges();
    }
  }
}
