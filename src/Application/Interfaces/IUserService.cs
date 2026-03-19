using UniBet.Application.Commands;
using UniBet.Domain.Entities;

namespace UniBet.Application.Interfaces
{
  public interface IUserService : IBaseService<User>
  {
    void Update(UpdateUserCommand command);
  }
}
