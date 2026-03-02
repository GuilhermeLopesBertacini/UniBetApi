using Microsoft.EntityFrameworkCore;
using UniBet.Core.Domain.Entities;

namespace UniBet.Infrastructure.Persistence
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>(entity =>
      {
        entity.ToTable("tb_users");

        entity.Property(u => u.Email)
          .HasMaxLength(255)
          .IsRequired();

        entity.HasIndex(u => u.Email)
          .IsUnique();

        entity.HasIndex(u => u.Cpf)
          .IsUnique();

        entity.Property(u => u.Balance)
          .HasColumnType("decimal(9,2)");
      });
    }
  }
}
