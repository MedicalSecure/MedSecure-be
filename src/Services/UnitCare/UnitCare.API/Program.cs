// Create a web application builder
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(["http://localhost:4200", "https://localhost:4200"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();

                      });
});

// Add services to the container
builder
    .Services
    .AddApplicationServices(builder.Configuration)  // Add application services layer 
    .AddInfrastructureServices(builder.Configuration)  // Add infrastructure services layer 
    .AddApiServices(builder.Configuration);  // Add API services layer 

var app = builder.Build();  // Build the application
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline
app.UseApiServices();  // Configure API-related middleware

if (app.Environment.IsDevelopment())
{
    // Configure Swagger for API documentation in development environment
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnitCare API V1");  // Configure Swagger UI endpoint
    });

    // Initialize the database asynchronously with mock data 
   await app.InitialiseDatabaseAsync();
}

// Start the application
app.Run();
