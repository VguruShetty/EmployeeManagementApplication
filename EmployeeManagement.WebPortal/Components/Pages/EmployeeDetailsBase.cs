using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        protected string Coordinates { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X: {e.ClientX}, Y: {e.ClientY}";
        }
    }
}
