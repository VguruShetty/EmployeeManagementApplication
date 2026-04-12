using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.WebPortal.Components.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
    }
}
