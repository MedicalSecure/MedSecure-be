
namespace Waste.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        // Add services to this container
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}