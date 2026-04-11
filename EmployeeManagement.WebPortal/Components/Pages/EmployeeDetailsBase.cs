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
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = string.Empty;

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

        protected void Button_Click()
        {
            if (CssClass == "HideFooter")
            {
                CssClass = string.Empty;
                ButtonText = "Hide Footer";
            }
            else
            {
                CssClass = "HideFooter";
                ButtonText = "Show Footer";
            }
        }
    }
}