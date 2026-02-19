using UniBet.Entities;
using UniBet.Interfaces.IServices;
using UniBet.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UniBet.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
      this._repository = repository;
    }

    public List<User> GetUsers()
    {
      throw new NotImplementedException();
    }

    public User GetById(Guid id)
    {
      User user = _repository.GetById(id); 
      if (user == null) return null;
      return user;
    }
    
    public User CreateUser(User user)
    {
      throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
      throw new NotImplementedException();
    }

    public void DeleteUser(Guid Id)
    {
      throw new NotImplementedException();
    }
  }
}