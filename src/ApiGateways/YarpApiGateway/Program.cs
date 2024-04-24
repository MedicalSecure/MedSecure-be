using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


// Add configuration to appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Add configuration to appsettings.local.json for Docker Compose
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