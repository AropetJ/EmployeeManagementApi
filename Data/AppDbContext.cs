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

            SeedData();

        }

        private void SeedData()
    {
        if (!Employees.Any())
        {
            Employees.AddRange(
                new Employee
                {
                    Id = 1,
                    Username = "john.doe",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890",
                    Department = "IT",
                    BaseSalary = 60000
                },

                new Employee
                {
                    Id = 2,
                    Username = "jane.smith",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Phone = "987-654-3210",
                    Department = "HR",
                    BaseSalary = 55000
                },

                new Employee
                {
                    Id = 3,
                    Username = "alice.johnson",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    Phone = "555-123-4567",
                    Department = "Marketing",
                    BaseSalary = 58000
                },

                new Employee
                {
                    Id = 4,
                    Username = "bob.robertson",
                    FirstName = "Bob",
                    LastName = "Robertson",
                    Email = "bob.robertson@example.com",
                    Phone = "333-555-9999",
                    Department = "Sales",
                    BaseSalary = 62000
                },

                new Employee
                {
                    Id = 5,
                    Username = "emily.wilson",
                    FirstName = "Emily",
                    LastName = "Wilson",
                    Email = "emily.wilson@example.com",
                    Phone = "777-888-4444",
                    Department = "Finance",
                    BaseSalary = 57000
                },

                new Employee
                {
                    Id = 6,
                    Username = "alex.miller",
                    FirstName = "Alex",
                    LastName = "Miller",
                    Email = "alex.miller@example.com",
                    Phone = "222-333-7777",
                    Department = "IT",
                    BaseSalary = 61000
                },

                new Employee
                {
                    Id = 7,
                    Username = "linda.jones",
                    FirstName = "Linda",
                    LastName = "Jones",
                    Email = "linda.jones@example.com",
                    Phone = "888-999-1111",
                    Department = "HR",
                    BaseSalary = 54000
                },

                new Employee
                {
                    Id = 8,
                    Username = "sam.thompson",
                    FirstName = "Sam",
                    LastName = "Thompson",
                    Email = "sam.thompson@example.com",
                    Phone = "111-222-3333",
                    Department = "Operations",
                    BaseSalary = 59000
                },

                new Employee
                {
                    Id = 9,
                    Username = "grace.anderson",
                    FirstName = "Grace",
                    LastName = "Anderson",
                    Email = "grace.anderson@example.com",
                    Phone = "666-777-2222",
                    Department = "Marketing",
                    BaseSalary = 58000
                },

                new Employee
                {
                    Id = 10,
                    Username = "michael.clark",
                    FirstName = "Michael",
                    LastName = "Clark",
                    Email = "michael.clark@example.com",
                    Phone = "444-666-8888",
                    Department = "Finance",
                    BaseSalary = 60000
                }
            );
            SaveChanges();
        }
    }

        // <summary>
        /// Gets or sets the salary of employees.   
        /// </summary>        
        public DbSet<Salary> Salaries { get; set; }

        /// <summary>
        /// Gets or sets the collection of employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Defines a unique index on the Email property in the User entity to prevent duplicate entries.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
