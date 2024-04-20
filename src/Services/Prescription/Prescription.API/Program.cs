using Prescription.Application;
using Prescription.Infrastructure;
using Prescription.Infrastructure.Database.Extensions;

namespace Prescription.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            /*
                        // Add services to the container.

                        builder.Services.AddControllers();*/
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            /*builder.Services.AddEndpointsApiExplorer();*/
            /*builder.Services.AddSwaggerGen();*/
            builder.Services.AddControllers();
            builder.Services.AddInfrastructureServices(builder.Configuration);// Add infrastructure services layer
            builder.Services.AddApplicationServices(builder.Configuration);  // Add application services layer
            builder.Services.AddApiServices(builder.Configuration);  // Add API services layer

            var app = builder.Build();
            // Configure the HTTP request pipeline
            app.UseApiServices();  // Configure API-related middleware

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prescription API V1");  // Configure Swagger UI endpoint
                });

                // Initialize the database asynchronously with mock data
                app.InitialiseDatabaseAsync();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}