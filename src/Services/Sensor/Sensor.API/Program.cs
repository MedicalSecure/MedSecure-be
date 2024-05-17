using Microsoft.Azure.Devices.Client;
using Sensor.Application.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Add application services layer 
builder.Services.AddApplicationServices(builder.Configuration);
// Add infrastructure services layer 
builder.Services.AddInfrastructureServices(builder.Configuration);
// Add API services layer 
builder.Services.AddApiServices(builder.Configuration);


var app = builder.Build();
app.UseApiServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Configure Swagger for API documentation in development environment
    app.UseSwagger();  // Enable Swagger middleware
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sensor API V1");  // Configure Swagger UI endpoint
    });

    // Initialize the database asynchronously with mock data 
   // await app.InitialiseDatabaseAsync();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseAuthorization();
app.UseAuthentication();

app.Run();
