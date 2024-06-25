using System.Threading.Tasks;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Repositories
{
    /// <summary>
    /// Represents a repository for managing user data.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddUserAsync(User user);

        /// <summary>
        /// Retrieves a user by their username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user, or null if not found.</returns>
        Task<User?> GetByUsernameAsync(string username);
    }
}
