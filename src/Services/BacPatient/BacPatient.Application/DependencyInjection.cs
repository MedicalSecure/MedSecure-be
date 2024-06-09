namespace BacPatient.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add MediatR for handling commands and queries
        services.AddMediatR(config =>
        {
            // Register handlers from the executing assembly
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            // Add behaviors for validation and logging
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddHttpClient("api", c =>
        {
            c.BaseAddress = new Uri("http://yarpapigateway:8080");
            c.Timeout = TimeSpan.FromSeconds(10);
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        });

        // Add feature management for managing feature flags
        services.AddFeatureManagement();

        // Add message broker for async communication
        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        // Return the modified service collection
        return services;
    }
}