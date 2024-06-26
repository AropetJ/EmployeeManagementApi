using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Repositories;

namespace EmployeeManagementApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IEmployeeRepository employeeRepository, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
        }

        public async Task<bool> RegisterUserAsync(RegisterModel model)
        {
            var existingUser = await _employeeRepository.GetByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return false; // Email already exists
            }

            var employee = new Employee
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Department = model.Department,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _employeeRepository.AddEmployeeAsync(employee);
            return true;
        }

        public async Task<string?> LoginUserAsync(LoginModel model)
        {
            var employee = await _employeeRepository.GetByUsernameAsync(model.Username);

            if (employee == null || !BCrypt.Net.BCrypt.Verify(model.Password, employee.PasswordHash))
            {
                return null;
            }

            return GenerateJwtToken(employee);
        }

        private string GenerateJwtToken(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, employee.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
