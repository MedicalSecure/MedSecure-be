using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var frontEndUrl = Environment.GetEnvironmentVariable("FRONTEND_URL");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(frontEndUrl ?? "*")
                           .AllowAnyHeader() // Allow any header
                                .AllowAnyMethod();
                      });
});

// Check if the ASPNETCORE_ENVIRONMENT environment variable is set to "local"
var isDevEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

// If it's the local environment, load only the appsettings.local.json file
if (isDevEnv)
{
    builder.Configuration.AddJsonFile("appsettings.local.json", optional: false, reloadOnChange: true);
}
else
{
    // Otherwise, load the default appsettings.json file
    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
}

// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(1);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseHsts();

// Configure the HTTP request pipeline.
app.UseRateLimiter();

app.MapReverseProxy();

app.Run();