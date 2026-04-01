using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = null;
            await Task.Run(LoadEmployees);
            //return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(7000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Ibrahim",
                Email = "John.Ibrahim@gmail.com",
                DateOfBirth = new DateTime(1989, 9, 10),
                Gender = Gender.Male,
                Department = new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Physics"
                },
                PhotoPath = "images/John.jpeg"
            };
            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Jalina",
                LastName = "Ibrahim",
                Email = "Jalina.Ibrahim@gmail.com",
                DateOfBirth = new DateTime(1994, 4, 14),
                Gender = Gender.Female,
                Department = new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Biology"
                },
                PhotoPath = "images/Jalina.jpeg"
            };
            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Jack",
                Email = "Mary.Jack@gmail.com",
                DateOfBirth = new DateTime(1994, 4, 14),
                Gender = Gender.Female,
                Department = new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Biology"
                },
                PhotoPath = "images/Mary.jpeg"
            };
            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Goli",
                LastName = "Patel",
                Email = "Goli.Patel@gmail.com",
                DateOfBirth = new DateTime(1985, 1, 19),
                Gender = Gender.Male,
                Department = new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Chemistry"
                },
                PhotoPath = "images/Goli.jpeg"
            };
            Employee e5 = new Employee
            {
                EmployeeId = 5,
                FirstName = "Sharath",
                LastName = "Roy",
                Email = "Sharath.Roy@gmail.com",
                DateOfBirth = new DateTime(1991, 12, 07),
                Gender = Gender.Male,
                Department = new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Mathmatics"
                },
                PhotoPath = "images/Sharath.jpeg"
            };
            Employees = new List<Employee> { e1, e2, e3, e4, e5 };

            //StateHasChanged();
        }

    }
}
