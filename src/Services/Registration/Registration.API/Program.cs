// Create a web application builder
using Registartion.Infrastructure;
using Registration.API;
using Registration.Application;
using Registration.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder
    .Services
    .AddApplicationServices(builder.Configuration)  // Add application services layer 
    .AddInfrastructureServices(builder.Configuration)  // Add infrastructure services layer 
    .AddApiServices(builder.Configuration);  // Add API services layer 

var app = builder.Build();  // Build the application

// Configure the HTTP request pipeline
app.UseApiServices();  // Configure API-related middleware

if (app.Environment.IsDevelopment())
{
    // Configure Swagger for API documentation in development environment
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registration API V1");  // Configure Swagger UI endpoint
    });

    // Initialize the database asynchronously with mock data 
    await app.InitialiseDatabaseAsync();
}

// Start the application
app.Run();
