using UniBet.Entities;
using UniBet.Interfaces.IServices;
using UniBet.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using UniBet.Exceptions;

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
      List<User> users = this._repository.GetUsers();
      return users;
    }

    public User GetUserById(Guid id)
    {
      User user = this._repository.GetUserById(id); 
      if (user == null) throw new NotFoundException($"User with Id {id} not found.");
      return user;
    }
    
    public User CreateUser(User user)
    {
      User createdUser = this._repository.CreateUser(user);
      return createdUser;
    }

    public void UpdateUser(User user)
    {
      User existingUser = this._repository.GetUserById(user.Id);
      if (existingUser == null) throw new NotFoundException($"User with Id {user.Id} not found.");
      this._repository.UpdateUser(user);
    }

    public void DeleteUser(Guid id)
    {
      User user = this._repository.GetUserById(id);
      if (user == null) throw new NotFoundException($"User with Id {id} not found.");
      this._repository.DeleteUser(user);
    }
  }
}