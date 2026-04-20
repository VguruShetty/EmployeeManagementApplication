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
        [Parameter]
        public EventCallback OnEmployeeDeleted { get; set; }
        [Inject]
        protected IEmployeeService EmployeeService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; } // <-- Add this line
        protected Shared.Components.ConfirmationBase DeleteConfirmation { get; set; }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
        protected void Delete()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
        //protected async Task Delete()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        //   // NavigationManager.NavigateTo($"/", true);
        //}
    }
}
