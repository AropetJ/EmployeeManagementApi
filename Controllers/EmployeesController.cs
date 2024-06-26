using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories;

namespace EmployeeManagementApi.Controllers
{
    /// <summary>
    /// Controller class for managing employees.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeeRepository.GetAllEmployeesAsync());
        }

        /// <summary>
        /// Gets an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The employee with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>The created employee.</returns>
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        /// <summary>
        /// Deletes an employee.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>No content.</returns>
        /// [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportEmployeesToCsv()
        {
            var csvData = await _employeeRepository.ExportEmployeesToCsvAsync();
            return File(csvData, "text/csv", "employees.csv");
        }
    }
}
