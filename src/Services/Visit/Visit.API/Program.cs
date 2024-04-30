using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();

                      });
});

// Add services to the container.
// Add application services layer 
builder.Services.AddApplicationServices(builder.Configuration);
// Add infrastructure services layer 
builder.Services.AddInfrastructureServices(builder.Configuration);
// Add API services layer 
builder.Services.AddApiServices(builder.Configuration);

//build app
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
app.UseApiServices();  // Configure API-related middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visit API V1");  // Configure Swagger UI endpoint
    });

    // Initialize the database asynchronously with mock data 
    await app.InitialiseDatabaseAsync();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


app.Run();


