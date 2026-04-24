using EmployeeManagement.WebPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.WebPortal.Components.Account.Pages.Manage
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        // Use your custom User class instead of IdentityUser
        private readonly SignInManager<EmployeeManagementWebPortalUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<EmployeeManagementWebPortalUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // Logic for when someone clicks the NavLink (GET request)
        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out via link.");

            return LocalRedirect("~/"); // Redirect to home page immediately
        }

        // Logic for when a Form is submitted (POST request)
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out via form.");

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect("~/");
            }
        }
    }
}
