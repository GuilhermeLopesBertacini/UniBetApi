using Microsoft.EntityFrameworkCore;
using UniBet.Core.Application.Ports;
using UniBet.Core.Domain.Entities;

namespace UniBet.Infrastructure.Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext context)
    {
      _db = context;
    }

    public List<User> GetAll()
    {
      return _db.Users.ToList();
    }

    public User? GetById(Guid id)
    {
      return _db.Users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(User user)
    {
      User createdUser = _db.Users.Add(user).Entity;
      _db.SaveChanges();
      return createdUser;
    }

    public void Update(User user)
    {
      _db.Users.Update(user);
      _db.SaveChanges();
    }

    public void Delete(User user)
    {
      _db.Users.Remove(user);
      _db.SaveChanges();
    }
  }
}
