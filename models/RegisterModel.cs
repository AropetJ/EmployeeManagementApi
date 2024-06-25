namespace EmployeeManagementApi.Models
{
    /// <summary>
    /// Represents the model for registering a new user.
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
