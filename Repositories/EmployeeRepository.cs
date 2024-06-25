using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Data;

namespace EmployeeManagementApi.Repositories
{
    /// <summary>
    /// Repository class for managing operations related to employees in the database.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing employees.</param>
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all employees asynchronously from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of employees.</returns>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        /// <summary>
        /// Retrieves an employee by id asynchronously from the database.
        /// </summary>
        /// <param name="id">The id of the employee to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the employee, if found; otherwise null.</returns>
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        /// <summary>
        /// Adds a new employee to the database asynchronously.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added employee.</returns>
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Updates an existing employee in the database asynchronously.
        /// </summary>
        /// <param name="employee">The updated employee information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated employee.</returns>
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        /// <summary>
        /// Deletes an employee from the database asynchronously.
        /// </summary>
        /// <param name="id">The id of the employee to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates if the deletion was successful (true) or the employee was not found (false).</returns>
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}