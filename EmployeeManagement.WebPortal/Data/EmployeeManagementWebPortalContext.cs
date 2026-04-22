using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.WebPortal.Data;

namespace EmployeeManagement.WebPortal.Data
{
    public class EmployeeManagementWebPortalContext(DbContextOptions<EmployeeManagementWebPortalContext> options) : IdentityDbContext<EmployeeManagementWebPortalUser>(options)
    {
    }
}
