using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Data;
using CsvHelper;
using System.Text;
using System.Globalization;

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
            var existingEmployee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == employee.Email);

            if (existingEmployee != null)
            {
                
                return null;
            }

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

        /// <summary>
        /// Retrieves a user by their username from the database asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user, or null if not found.</returns>
        public async Task<Employee?> GetByUsernameAsync(string username)
        {
            return await _context.Employees.SingleOrDefaultAsync(u => u.Username == username);
        }

        /// <summary>
        /// Retrieves an employee by their email address from the database asynchronously.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user, or null if not found.</returns>
        /// <remarks>This method is used to ensure that no duplicate email addresses are stored in the database.</remarks>
        /// <returns></returns>
        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.SingleOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// Exports the employees to a CSV file and returns the file content as a byte array.
        /// </summary>
        /// <returns>A byte array representing the CSV file content.</returns>
        public async Task<byte[]> ExportEmployeesToCsvAsync()
        {
            var employees = await _context.Employees.ToListAsync();

            // Using CsvHelper library to convert employees to CSV bytes
            using (var memoryStream = new System.IO.MemoryStream())
            using (var writer = new System.IO.StreamWriter(memoryStream, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(employees);
                writer.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}