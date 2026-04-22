using EmployeeManagement.WebPortal.Data;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.WebPortal.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<EmployeeManagementWebPortalUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<EmployeeManagementWebPortalUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
