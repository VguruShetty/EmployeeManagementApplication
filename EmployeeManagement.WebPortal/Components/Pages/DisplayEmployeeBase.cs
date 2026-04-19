using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Inject]
        protected IEmployeeService EmployeeService { get; set; }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
        protected async Task Delete()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            
        }
    }
}
