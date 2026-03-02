using UniBet.Core.Application.Ports;
using UniBet.Core.Domain.Entities;

namespace UniBet.Infrastructure.Persistence.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(AppDbContext context) : base(context) { }

    // Add User-specific query methods here
  }
}
