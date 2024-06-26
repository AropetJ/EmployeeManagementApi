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

                /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user, or null if not found.</returns>
        Task<Employee?> GetByUsernameAsync(string username);

        /// <summary>
        /// Retrieves a user by their email address asynchronously.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user, or null if not found.</returns>
        /// <remarks>This method is used to ensure that no duplicate email addresses are stored in the database.</remarks>
        Task<Employee?> GetByEmailAsync(string email);

        /// <summary>
        /// Exports employees to a CSV file asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains the exported CSV file as a byte array.</returns>
        Task<byte[]> ExportEmployeesToCsvAsync();
    }
}
