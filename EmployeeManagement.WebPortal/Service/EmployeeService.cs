using System.Net.Http.Json;
using EmployeeManagement.Models;

namespace EmployeeManagement.WebPortal.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> CreateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            //var response = await httpClient.PostAsJsonAsync("/api/employees", employee);
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadFromJsonAsync<Employee>();
            var response = await httpClient.PostAsJsonAsync("/api/employees", employee);

            if (!response.IsSuccessStatusCode)
            {
                // Read the detailed error message from the API
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {errorContent}");
                throw new Exception($"API Error: {response.StatusCode} - {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/employees/{id}");
            response.EnsureSuccessStatusCode();
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

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await httpClient.PutAsJsonAsync("/api/employees", employee);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }
    }
}
