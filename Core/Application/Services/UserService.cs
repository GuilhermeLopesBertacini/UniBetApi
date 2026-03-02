using UniBet.Core.Application.Commands;
using UniBet.Core.Application.Ports;
using UniBet.Core.Domain.Entities;
using UniBet.Core.Domain.Exceptions;

namespace UniBet.Core.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
      _repository = repository;
    }

    public List<User> GetAll()
    {
      return _repository.GetAll();
    }

    public User GetById(Guid id)
    {
      User user = _repository.GetById(id);
      if (user == null) throw new NotFoundException($"User with Id {id} not found.");
      return user;
    }

    public User Create(User user)
    {
      return _repository.Create(user);
    }

    public void Update(UpdateUserCommand command)
    {
      User existingUser = _repository.GetById(command.Id);
      if (existingUser == null) throw new NotFoundException($"User with Id {command.Id} not found.");
      existingUser.Update(command.FirstName, command.LastName, command.Email);
      _repository.Update(existingUser);
    }

    public void Delete(Guid id)
    {
      User user = _repository.GetById(id);
      if (user == null) throw new NotFoundException($"User with Id {id} not found.");
      _repository.Delete(user);
    }
  }
}
