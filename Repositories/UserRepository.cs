using UniBet.Entities;
using UniBet.Interfaces.IRepositories;
using UniBet.Context;
using Microsoft.EntityFrameworkCore;

namespace UniBet.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly BaseContext _context;
    public UserRepository(BaseContext context) {
      _context = context;
    }
    public List<User> GetUsers()
    {
      return _context.Users.ToList();
    }

    public User GetUserById(Guid Id)
    {
      return _context.Users.FirstOrDefault(u => u.Id == Id);
    }

    public User CreateUser(User user)
    {
      User createdUser = _context.Users.Add(user).Entity;
      _context.SaveChanges();
      return createdUser;
    }

    public void UpdateUser(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void DeleteUser(Guid Id)
    {
      User user = _context.Users.Find(Id);
      if (user != null)
      {
        _context.Users.Remove(user);
        _context.SaveChanges();
      }
    }
  }
}