using EmployeeManagement.Models;
using EmployeeManagement.WebPortal.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public string Coordinates { get; set; } = string.Empty;

        public bool isFooterVisible { get; set; } = false;

        public string ButtonText => isFooterVisible ? "Hide Footer" : "Show Footer";

        [Inject]
        public IEmployeeService EmployeeService { get; set; } = null!;

        [Parameter]
        public string? Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX} Y = {e.ClientY}";
        }
        public void ToggleFooter()
        {
            isFooterVisible = !isFooterVisible;
            // 2. Explicitly tell Blazor to re-render the UI
            this.StateHasChanged();
        }
    }
}