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
               new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId = 4, DepartmentName = "Admin" });

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
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jalina",
                    LastName = "Ibrahim",
                    Email = "Jalina.Ibrahim@gmail.com",
                    DateOfBirth = new DateTime(1994, 4, 14),
                    Gender = Gender.Female,
                    DepartmentId = 2,
                    PhotoPath = "images/Jalina.jpeg"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Mary",
                    LastName = "Jack",
                    Email = "Mary.Jack@gmail.com",
                    DateOfBirth = new DateTime(1994, 4, 14),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/Mary.jpeg"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Sharath",
                    LastName = "Roy",
                    Email = "Sharath.Roy@gmail.com",
                    DateOfBirth = new DateTime(1991, 12, 07),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/Sharath.jpeg"
                });
        }
    }
}
