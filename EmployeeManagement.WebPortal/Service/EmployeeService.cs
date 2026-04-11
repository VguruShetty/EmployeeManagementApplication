using EmployeeManagement.Models;

namespace EmployeeManagement.WebPortal.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await httpClient.GetFromJsonAsync<Employee>($"/api/employees/{id}");
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with id {id} was not found.");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("/api/employees");
        }
    }
}
