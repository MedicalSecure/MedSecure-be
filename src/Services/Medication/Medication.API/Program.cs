// Create a web application builder
using Medication.Application.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder
    .Services
    .AddApplicationServices(builder.Configuration)  // Add application services layer
    .AddInfrastructureServices(builder.Configuration)  // Add infrastructure services layer
    .AddApiServices(builder.Configuration);  // Add API services layer

//AddSignalR
builder.Services.AddSignalR();

//allow cross origin TODO REMOVE from here and place it in my API GATEWAY!!
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200","https://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                      });
});

var app = builder.Build();  // Build the application
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline
app.UseApiServices();  // Configure API-related middleware

// Inject SignalR Hubs
app.InjectHubs();

if (app.Environment.IsDevelopment())
{
    // Configure Swagger for API documentation in development environment
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medication API V1");  // Configure Swagger UI endpoint
    });

    // Initialize the database asynchronously with mock data
    await app.InitialiseDatabaseAsync();
}

// Start the application
app.Run();