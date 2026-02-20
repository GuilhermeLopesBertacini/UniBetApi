using UniBet.Entities;
using Microsoft.EntityFrameWorkCore;
using System.Reflection.Metadata;

namespace Unibet.Context
{
    public class BaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options): base(options)
        {
        }

        protected override OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .hasKey(u => u.Id)
        }
    }
}