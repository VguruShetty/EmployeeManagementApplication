using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EditEmployeeBase : Component
    {
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public string PageHeaderText { get; set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        public string DepartmentId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if(employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));

            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);

            //DepartmentId = Employee.DepartmentId.ToString();


            //EditEmployeeModel.ConfirmEmail = Employee.Email;

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.Department = Employee.Department;
        }
        protected async Task HandelValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            Employee result = null;
            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if (result != null){
                NavigationManager.NavigateTo($"/");
            }                    
            
        }
        protected Shared.Components.ConfirmationBase DeleteConfirmation { get; set; }

        protected void Delete()
        {
            DeleteConfirmation.Show();
        }
        [Parameter]
        public EventCallback OnEmployeeDeleted { get; set; }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
                
                NavigationManager.NavigateTo("/");
            }
        }
        protected async Task ConfirmDelete_Click1(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                // 1. Get the ID safely
                int.TryParse(Id, out int employeeId);

                // 2. If for some reason 'Id' is null, fallback to the model
                if (employeeId == 0)
                {
                    employeeId = EditEmployeeModel.EmployeeId;
                }

                if (employeeId != 0)
                {
                    await EmployeeService.DeleteEmployee(employeeId);
                    NavigationManager.NavigateTo("/");
                }
            }
            //if (deleteConfirmed)
            //{
            //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            //    NavigationManager.NavigateTo($"/");
            //}
        }
    }
}
