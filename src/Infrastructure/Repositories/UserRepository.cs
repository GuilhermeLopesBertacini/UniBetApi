using UniBet.Application.Interfaces;
using UniBet.Domain.Entities;

namespace UniBet.Infrastructure.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(AppDbContext context) : base(context) { }

    // Add User-specific query methods here
  }
}
