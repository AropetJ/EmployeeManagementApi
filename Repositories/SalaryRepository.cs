using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Data;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories
{
    /// <summary>
    /// Represents a repository for managing salaries.
    /// </summary>
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all salaries asynchronously.
        /// </summary>
        /// <returns>A collection of <see cref="Salary"/> objects.</returns>
        public async Task<IEnumerable<Salary>> GetAllSalariesAsync()
        {
            return await _context.Salaries.ToListAsync();
        }

        /// <summary>
        /// Retrieves salaries by employee ID asynchronously.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A collection of <see cref="Salary"/> objects.</returns>
        public async Task<IEnumerable<Salary>> GetSalariesByEmployeeIdAsync(int employeeId)
        {
            return await _context.Salaries.Where(s => s.EmployeeId == employeeId).ToListAsync();
        }

        /// <summary>
        /// Adds a new salary asynchronously.
        /// </summary>
        /// <param name="salary">The salary to add.</param>
        public async Task AddSalaryAsync(Salary salary)
        {
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing salary asynchronously.
        /// </summary>
        /// <param name="salary">The salary to update.</param>
        public async Task UpdateSalaryAsync(Salary salary)
        {
            _context.Entry(salary).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a salary by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the salary to delete.</param>
        public async Task DeleteSalaryAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                await _context.SaveChangesAsync();
            }
        }
    }
}
