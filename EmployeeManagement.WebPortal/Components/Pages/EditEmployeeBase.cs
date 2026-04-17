using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EditEmployeeBase : Component
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public string DepartmentId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();

            EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            EditEmployeeModel.FirstName = Employee.FirstName;
            EditEmployeeModel.LastName = Employee.LastName;
            EditEmployeeModel.Email = Employee.Email;
            EditEmployeeModel.ConfirmEmail = Employee.Email;
            EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            EditEmployeeModel.Gender = Employee.Gender;
            EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            EditEmployeeModel.Department = Employee.Department;
        }
    }
}
