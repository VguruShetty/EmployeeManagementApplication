using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetEmployees(int id)
        {
            try
            {
                return Ok(await employeeRepository.GetEmployee(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var emp = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployees), new { id = emp.EmployeeId }, emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var emp = await employeeRepository.GetEmployee(employee.EmployeeId);
                if (emp == null)
                {
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var emp = await employeeRepository.GetEmployee(id);
                if (emp == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                await employeeRepository.DeleteEmployee(id);
                return Ok(emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data from database");
            }
        }
        [HttpGet("{search}/{name}/{gender?}")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(string name, Gender? gender)
        {
            try
            {
                var result = await employeeRepository.SearchEmployee(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound("No employees found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error searching data from database");
            }

        }
    }
}
