using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Services;

namespace EmployeeManagementApi.Controllers
{
    /// <summary>
    /// Controller for handling authentication related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The registration model.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the registration.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authService.RegisterUserAsync(model);
            if (!result)
            {
                return BadRequest("Registration failed");
            }

            return Ok("Registration successful");
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="model">The login model.</param>
        /// /// <returns>An <see cref="IActionResult"/> representing the result of the login.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token = await _authService.LoginUserAsync(model);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
