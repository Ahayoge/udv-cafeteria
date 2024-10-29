using Microsoft.EntityFrameworkCore;
using UDV_Benefits.Domain.Models;

namespace UDV_Benefits.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO: перенести в отдельный конфиг для каждой entity
            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(w => w.Position)
                .HasConversion<string>();
            modelBuilder.Entity<Employee>()
                .Property(w => w.Department)
                .HasConversion<string>();
            modelBuilder.Entity<Employee>()
                .Property(w => w.Company)
                .HasConversion<string>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
