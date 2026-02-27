using UniBet.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace UniBet.Context
{
    public class BaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options): base(options)
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

                entity.HasIndex(u => u.Rg)
                .IsUnique();

                entity.Property(u => u.Balance)
                .HasColumnType("decimal(9,2)");
            });
            
        }
    }
}