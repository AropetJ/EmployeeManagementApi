namespace EmployeeManagementApi.Models
{
    /// <summary>
    /// Represents a login model for authentication.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
