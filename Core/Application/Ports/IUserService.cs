using UniBet.Core.Application.Commands;
using UniBet.Core.Domain.Entities;

namespace UniBet.Core.Application.Ports
{
  public interface IUserService
  {
    List<User> GetAll();
    User GetById(Guid id);
    User Create(User user);
    void Update(UpdateUserCommand command);
    void Delete(Guid id);
  }
}
