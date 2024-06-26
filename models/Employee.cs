namespace EmployeeManagementApi.Models
{
    /// <summary>
    /// Represents an Employee entity.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the employee.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the employee.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the base salary amount.
        /// </summary>
        public decimal BaseSalary { get; set; }

        /// <summary>
        /// Gets or sets the password hash of the user.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
    }
}
