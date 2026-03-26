using UniBet.Domain.Entities;
using UniBet.Presentation.DTOs;

namespace UniBet.Application.Interfaces
{
  public interface IUserService : IBaseService<User>
  {
    void ChangeProfile(Guid id, ChangeProfileRequest request);
  }
}
