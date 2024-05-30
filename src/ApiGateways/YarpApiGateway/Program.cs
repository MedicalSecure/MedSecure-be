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

// Ajouter la configuration à partir de appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Ajouter la configuration à partir de appsettings.local.json pour Docker Compose
//builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);

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


// Configure the HTTP request pipeline.
app.UseRateLimiter();

app.MapReverseProxy();

app.Run();