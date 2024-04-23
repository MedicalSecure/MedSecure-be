using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Ajouter la configuration � partir de appsettings.local.json pour Docker Compose
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

// Ajouter la configuration � partir de appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Ajouter la configuration � partir de appsettings.local.json pour Docker Compose
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRateLimiter();

app.MapReverseProxy();

app.Run();