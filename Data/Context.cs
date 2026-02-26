using UniBet.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Unibet.Context
{
    public class BaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        }
    }
}