﻿
namespace Waste.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Add Carter as the routing framework for the API
        services.AddCarter();

        // Add custom exception handling using CustomExceptionHandler
        services.AddExceptionHandler<CustomExceptionHandler>();

        // Add health checks for SQL Server database using the provided connection string
        services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);

        // Return the modified service collection
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // Map Carter routes
        app.MapCarter();

        // Configure exception handling
        app.UseExceptionHandler(options => { });

        // Configure health checks endpoint and response writer
        app.UseHealthChecks(
            "/health",
            new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
        );

        // Return the configured WebApplication
        return app;
    }
}