using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories
{
    /// <summary>
    /// Represents a repository for managing salaries.
    /// </summary>
    public interface ISalaryRepository
    {
        /// <summary>
        /// Retrieves all salaries.
        /// </summary>
        /// <returns>A collection of all salaries.</returns>
        Task<IEnumerable<Salary>> GetAllSalariesAsync();

        /// <summary>
        /// Retrieves salaries by employee ID.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A collection of salaries for the specified employee.</returns>
        Task<IEnumerable<Salary>> GetSalariesByEmployeeIdAsync(int employeeId);

        /// <summary>
        /// Adds a new salary.
        /// </summary>
        /// <param name="salary">The salary to add.</param>
        Task AddSalaryAsync(Salary salary);

        /// <summary>
        /// Updates an existing salary.
        /// </summary>
        /// <param name="salary">The salary to update.</param>
        Task UpdateSalaryAsync(Salary salary);

        /// <summary>
        /// Deletes a salary by ID.
        /// </summary>
        /// <param name="id">The ID of the salary to delete.</param>
        Task DeleteSalaryAsync(int id);
    }
}
