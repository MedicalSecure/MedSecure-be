var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services.AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

//Async Communication Services
//builder.Services.AddMessageBroker(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipline.
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
