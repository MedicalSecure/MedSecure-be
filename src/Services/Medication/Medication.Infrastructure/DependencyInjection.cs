namespace Medication.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        // Retrieve the database connection string from IConfiguration
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to the container.
        // Register AuditableEntityInterceptor and DispatchDomainEventsInterceptor as scoped services
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        // Add ApplicationDbContext to the service collection with Entity Framework Core
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            // Add interceptors to the DbContext options
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            // Use SQL Server with the provided connection string
            options.UseSqlServer(connectionString);
        });

        // Register IApplicationDbContext and ApplicationDbContext for dependency injection
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        // Return the modified service collection
        return services;
    }
}
