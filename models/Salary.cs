namespace EmployeeManagementApi.Models
{
    /// <summary>
    /// Represents the salary information for an employee.
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Gets or sets the unique identifier for the salary.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the base salary amount.
        /// </summary>
        public decimal BaseSalary { get; set; }

        /// <summary>
        /// Gets or sets the bonus amount.
        /// </summary>
        public decimal Bonus { get; set; }

        /// <summary>
        /// Gets or sets the date of the salary.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
