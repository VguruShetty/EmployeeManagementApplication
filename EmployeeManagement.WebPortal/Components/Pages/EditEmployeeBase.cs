using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EditEmployeeBase : Component
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
