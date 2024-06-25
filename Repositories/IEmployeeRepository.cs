using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories
{
    /// <summary>
    /// Represents the interface for managing employees.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Retrieves all employees asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of employees.</returns>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        /// <summary>
        /// Retrieves an employee by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the employee with the specified ID, or null if not found.</returns>
        Task<Employee?> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Adds a new employee asynchronously.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added employee.</returns>
        Task<Employee> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Updates an existing employee asynchronously.
        /// </summary>
        /// <param name="employee">The employee to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated employee.</returns>
        Task<Employee> UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Deletes an employee by their ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the employee was successfully deleted.</returns>
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
