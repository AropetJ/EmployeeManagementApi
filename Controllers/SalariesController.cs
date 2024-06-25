using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    /// <summary>
    /// Controller for managing salaries.
    /// </summary>
    [ApiController]
    [Route("api/salaries")]
    public class SalariesController : ControllerBase
    {
        private readonly ISalaryRepository _salaryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalariesController"/> class.
        /// </summary>
        /// <param name="salaryRepository">The salary repository.</param>
        public SalariesController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        /// <summary>
        /// Gets all salaries.
        /// </summary>
        /// <returns>A collection of all salaries.</returns>
        [HttpGet]
        public async Task<IEnumerable<Salary>> GetAllSalaries()
        {
            return await _salaryRepository.GetAllSalariesAsync();
        }

        /// <summary>
        /// Gets salaries by employee ID.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <returns>A collection of salaries for the specified employee.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalariesByEmployeeId(int id)
        {
            var salaries = await _salaryRepository.GetSalariesByEmployeeIdAsync(id);
            if (salaries == null)
            {
                return NotFound();
            }
            return Ok(salaries);
        }

        /// <summary>
        /// Adds a new salary.
        /// </summary>
        /// <param name="salary">The salary to add.</param>
        /// <returns>The created salary.</returns>
        [HttpPost]
        public async Task<ActionResult<Salary>> AddSalary(Salary salary)
        {
            await _salaryRepository.AddSalaryAsync(salary);
            return CreatedAtAction(nameof(GetSalariesByEmployeeId), new { id = salary.Id }, salary);
        }

        /// <summary>
        /// Updates an existing salary.
        /// </summary>
        /// <param name="id">The ID of the salary to update.</param>
        /// <param name="salary">The updated salary.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalary(int id, Salary salary)
        {
            if (id != salary.Id)
            {
                return BadRequest();
            }

            await _salaryRepository.UpdateSalaryAsync(salary);
            return NoContent();
        }

        /// <summary>
        /// Deletes a salary.
        /// </summary>
        /// <param name="id">The ID of the salary to delete.</param>
        /// <returns>No content.</returns>
        /// [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            await _salaryRepository.DeleteSalaryAsync(id);
            return NoContent();
        }
    }
}
