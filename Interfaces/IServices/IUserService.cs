using UniBet.Core.Commands;
using UniBet.Entities;

namespace UniBet.Interfaces.IServices
{
  public interface IUserService
  {
    public List<User> GetUsers();
    public User GetUserById(Guid Id);
    public User CreateUser(User user);
    public void UpdateUser(UpdateUserCommand command);
    public void DeleteUser(Guid Id);
  }
}