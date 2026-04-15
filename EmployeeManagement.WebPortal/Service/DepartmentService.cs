using EmployeeManagement.Models;

namespace EmployeeManagement.WebPortal.Service
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Department> GetDepartment(int id)
        {
            var department = await httpClient.GetFromJsonAsync<Department>($"/api/departments/{id}");
            if (department == null)
            {
                throw new InvalidOperationException($"Department with id {id} was not found.");
            }
            return department;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departments = await httpClient.GetFromJsonAsync<Department[]>("/api/departments");
            if (departments == null)
            {
                throw new InvalidOperationException("No departments were found.");
            }
            return departments;//D
        }
    }
}
