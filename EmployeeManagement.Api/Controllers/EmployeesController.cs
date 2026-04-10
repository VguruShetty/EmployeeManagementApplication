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
                if(employee == null)
                {
                    return BadRequest();
                }
                var emp = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployees), new { id = emp.EmployeeId}, emp);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }
    }
}
