
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader() // Allow any header
                                .AllowAnyMethod();
                      });
});
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Ajouter la configuration à partir de appsettings.local.json pour Docker Compose
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

// Ajouter la configuration à partir de appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Ajouter la configuration à partir de appsettings.local.json pour Docker Compose
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

// Add services to the container.
builder.Services.AddReverseProxy() // Configure reverse proxy for API gateway
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy")); // Load reverse proxy configuration from app settings

// Add rate limiting services
builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    // Configure fixed window rate limiter
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10); // Set window size to 10 seconds
        options.PermitLimit = 5; // Set permit limit to 5 requests
    });
});

// Add HttpContextAccessor to access HttpContext in services
builder.Services.AddHttpContextAccessor();

// Add CORS services to enable cross-origin requests
builder.Services.AddCors();

// Add Swagger services
// Add support for generating OpenAPI documentation
builder.Services.AddEndpointsApiExplorer(); // Adds API explorer services to generate OpenAPI documentation
builder.Services.AddSwaggerGen(); // Adds Swagger generation services to generate OpenAPI documentation


var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.

// Configure exception handling middleware
app.UseExceptionHandler("/error");


//Configure CORS to allow requests only from specified origins
app.UseCors(builder =>
{
   // builder.WithOrigins("https://localhost:4200", "http://localhost:4200") // Allow requests from specified origins
    builder.AllowAnyOrigin()
           .AllowAnyHeader() // Allow any headers in requests
           .AllowAnyMethod(); // Allow any HTTP methods in requests
});


// Redirect HTTP requests to HTTPS for enhanced security
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    // Configure Swagger for API documentation in development environment
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diet API V1");  // Configure Swagger UI endpoint
        c.RoutePrefix = "swagger"; // Use root URL for Swagger UI
    });
}

// Add JWT authorization middleware for authentication and authorization
app.UseMiddleware<JwtAuthorizationMiddleware>(new HttpAuthorizationOptions { AllowSwagger = app.Environment.IsDevelopment() });

// Add rate limiting middleware to restrict the rate of incoming requests
app.UseRateLimiter();

// Map reverse proxy routes to forward incoming requests to backend microservices
app.MapReverseProxy();

app.Run();