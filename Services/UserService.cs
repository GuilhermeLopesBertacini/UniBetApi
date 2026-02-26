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
      List<User> users = _repository.GetUsers();
      return users;
    }

    public User GetUserById(Guid id)
    {
      User user = _repository.GetUserById(id); 
      if (user == null) return null;
      return user;
    }
    
    public User CreateUser(User user)
    {
      User createdUser = _repository.CreateUser(user);
      return createdUser;
    }

    public void UpdateUser(User user)
    {
      _repository.UpdateUser(user);
    }

    public void DeleteUser(Guid Id)
    {
      _repository.DeleteUser(Id);
    }
  }
}