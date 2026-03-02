using UniBet.Core.Domain.Entities;

namespace UniBet.Core.Application.Ports
{
  public interface IUserRepository
  {
    List<User> GetAll();
    User? GetById(Guid id);
    User Create(User user);
    void Update(User user);
    void Delete(User user);
  }
}
