using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Shared.Components
{
    public class ConfirmationBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirm Delete";

        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete";

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        protected async Task OnConfirmationChange(bool isConfirmed)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(isConfirmed);
        }
    }
}
