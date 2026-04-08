using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for employee

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT"});
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 1, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 1, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 1, DepartmentName = "Admin" });

            // seed data for employee

            modelBuilder.Entity<Employee>().HasData(
                new Employee 
                { 
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "JohnDoe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.png"
                });
        }
    }
}
