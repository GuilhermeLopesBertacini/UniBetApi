using UniBet.Entities;

namespace UniBet.Interfaces.IRepositories
{
  public interface IUserRepository
  {
    public List<User> GetUsers();
    public User GetById(Guid Id);
    public User Create(User user);
    public void Update(User user);
    public void Delete(Guid id);
  }
}