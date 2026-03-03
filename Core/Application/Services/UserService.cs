using UniBet.Core.Application.Commands;
using UniBet.Core.Application.Ports;
using UniBet.Core.Domain.Entities;
using UniBet.Core.Domain.Exceptions;

namespace UniBet.Core.Application.Services
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
