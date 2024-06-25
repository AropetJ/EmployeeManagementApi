#!/bin/bash

# Install .NET SDK (change version as needed)
echo "Installing .NET SDK..."
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Install Entity Framework Core tools
echo "Installing Entity Framework Core tools..."
dotnet tool install --global dotnet-ef --version 8.0

# Install ASP.NET Core Code Generator (optional, for scaffolding)
echo "Installing ASP.NET Core Code Generator..."
dotnet tool install --global dotnet-aspnet-codegenerator --version 8.0

# Install additional packages if needed (e.g., Swagger)
# Example: Install Swashbuckle.AspNetCore for Swagger
echo "Installing Swashbuckle.AspNetCore for Swagger..."
dotnet add package Swashbuckle.AspNetCore --version 6.1.5

# Clean up
echo "Cleaning up..."
rm packages-microsoft-prod.deb

echo "Dependencies installed successfully."
