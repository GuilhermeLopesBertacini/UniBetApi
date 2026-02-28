using UniBet.Entities;
using UniBet.Interfaces.IRepositories;
using UniBet.Context;
using Microsoft.EntityFrameworkCore;
using UniBet.Exceptions;

namespace UniBet.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly BaseContext _db;
    public UserRepository(BaseContext context) {
      this._db = context;
    }
    public List<User> GetUsers()
    {
      return this._db.Users.ToList();
    }

    public User GetUserById(Guid id)
    {
      return this._db.Users.FirstOrDefault(u => u.Id == id);
    }

    public User CreateUser(User user)
    {
      User createdUser = this._db.Users.Add(user).Entity;
      this._db.SaveChanges();
      return createdUser;
    }

    public void UpdateUser(User user)
    {
      this._db.Users.Update(user);
      this._db.SaveChanges();
    }

    public void DeleteUser(User user)
    {
      this._db.Users.Remove(user);
      this._db.SaveChanges();
    }
  }
}