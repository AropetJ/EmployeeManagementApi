using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EmployeeManagementApi.Data;
using EmployeeManagementApi.Repositories;
using EmployeeManagementApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Load Configuration
var configuration = builder.Configuration;

// Add services to the container.
ConfigureServices(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("EmployeeDB"));
    
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<ISalaryRepository, SalaryRepository>();
    services.AddScoped<IAuthService, AuthService>();
    
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Configure JWT Authentication
    var jwtKey = configuration["Jwt:Key"];
    var key = jwtKey != null ? Encoding.ASCII.GetBytes(jwtKey) : null;
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

    // Configure CORS
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });
}

void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("AllowAll");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}
