using UniBet.Entities;

namespace UniBet.Interfaces.IRepositories
{
  public interface IUserRepository
  {
    public List<User> GetUsers();
    public User GetUserById(Guid Id);
    public User CreateUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
  }
}