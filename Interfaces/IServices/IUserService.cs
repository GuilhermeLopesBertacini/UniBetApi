using UniBet.Entities;

namespace UniBet.Interfaces.IServices
{
  public interface IUserService
  {
    public List<User> GetUsers();
    public User GetById(Guid Id);
    public User CreateUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(Guid Id);
  }
}