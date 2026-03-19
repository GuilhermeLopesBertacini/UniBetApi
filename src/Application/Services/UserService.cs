using UniBet.Application.Commands;
using UniBet.Application.Interfaces;
using UniBet.Domain.Entities;
using UniBet.Domain.Exceptions;

namespace UniBet.Application.Services
{
  public class UserService : BaseService<User>, IUserService
  {
    public UserService(IUserRepository repository) : base(repository) { }

    public void Update(UpdateUserCommand command)
    {
      User existingUser = GetById(command.Id);
      existingUser.Update(command.FirstName, command.LastName, command.Email);
      _repository.Update(existingUser);
    }
  }
}
