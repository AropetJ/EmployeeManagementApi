# Employee Management API

The Employee Management API is a RESTful service designed to manage employee data efficiently. This API provides endpoints for registering users, managing employees, and exporting employee data to CSV format.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
  - [Authentication](#authentication)
  - [Employees](#employees)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Authentication:**
  - Register new users.
  - Authenticate users using JWT.
  
- **Employee Management:**
  - Create, read, update, and delete employees.
  - Retrieve employees by ID.
  
- **Data Export:**
  - Export employee data to CSV format.

## Technologies Used

- **ASP.NET Core:** Framework for building APIs in C#.
- **Entity Framework Core:** Object-Relational Mapping (ORM) for database interaction.
- **Microsoft SQL Server:** Relational database management system.
- **Swagger:** API documentation and testing tool.
- **JWT (JSON Web Tokens):** Secure authentication method.
- **BCrypt.Net:** Password hashing library.

## Getting Started

Follow these instructions to get the API up and running on your local machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed.
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) with C# extension.
- Microsoft SQL Server or SQL Server Express for database (optional).

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your/repository.git
   cd EmployeeManagementApi
   ```

2. Restore dependencies and build the project:
   ```bash
   dotnet restore
   dotnet build
   ```

### Configuration

1. **Database Setup:**

   - Modify `appsettings.json` to configure your database connection string:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=EmployeeDb;Trusted_Connection=True;"
       },
       "Jwt": {
         "Key": "your_secret_key_here",
         "Issuer": "your_issuer_here",
         "Audience": "your_audience_here"
       }
     }
     ```

2. **Run Migrations:**

   Apply EF Core migrations to create the database schema:
   ```bash
   dotnet ef database update
   ```

3. **Run the Application:**

   Start the API server:
   ```bash
   dotnet run
   ```

   The API should now be running on `https://localhost:5001` (or `http://localhost:5000`).

## API Endpoints

### Authentication

- **POST /api/auth/register**
  - Register a new user with username and password.
  
- **POST /api/auth/login**
  - Authenticate user and receive a JWT token.

### Employees

- **GET /api/employees**
  - Retrieve all employees.

- **GET /api/employees/{id}**
  - Retrieve employee by ID.

- **POST /api/employees**
  - Add a new employee.

- **PUT /api/employees/{id}**
  - Update an existing employee.

- **DELETE /api/employees/{id}**
  - Delete an employee.

- **GET /api/employees/export**
  - Export employee data to CSV format.

## Testing

Use tools like **Postman** or **Swagger UI** to test each API endpoint. Ensure all CRUD operations are working as expected.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
