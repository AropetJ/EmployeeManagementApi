using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        // <summary>
        /// Gets or sets the salary of employees.   
        /// </summary>        
        public DbSet<Salary> Salaries { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the collection of salaries.
        /// </summary>
        /// public DbSet<Salary> Salaries { get; set; }
    }
}
