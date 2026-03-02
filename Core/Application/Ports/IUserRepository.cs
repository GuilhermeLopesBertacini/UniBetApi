using UniBet.Core.Domain.Entities;

namespace UniBet.Core.Application.Ports
{
  public interface IUserRepository : IBaseRepository<User>
  {
    // Add User-specific query methods here
  }
}
