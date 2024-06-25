using System.Threading.Tasks;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Services
{
    /// <summary>
    /// Represents an authentication service for managing user registration and login.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="model">The registration model containing user information.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the user registration was successful.</returns>
        Task<bool> RegisterUserAsync(RegisterModel model);

        /// <summary>
        /// Logs in a user asynchronously.
        /// </summary>
        /// <param name="model">The login model containing user credentials.</param>
        /// <returns>A task representing the asynchronous operation. The task result is the authentication token if the login is successful, otherwise null.</returns>
        Task<string?> LoginUserAsync(LoginModel model);
    }
}
