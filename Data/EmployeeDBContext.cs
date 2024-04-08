using EmployeeRestAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRestAPI.Data
{
    public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
