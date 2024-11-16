using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UDV_Benefits.Domain.Models;
using UDV_Benefits.Domain.ValueObject;

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

            modelBuilder.Entity<BenefitRequest>()
                .Property(br => br.Status)
                .HasConversion<string>();

            modelBuilder.Entity<EmployeeBenefit>()
                .Property(eb => eb.Status)
                .HasConversion<string>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BenefitRequest> BenefitRequests { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }
    }
}
