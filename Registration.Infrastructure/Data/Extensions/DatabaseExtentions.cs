
namespace Registration.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationsDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationsDbContext context)
    {
        // Clear existing data
        await ClearDataAsync(context);

        await SeedPatientAsync(context);
        
    }

    private static async Task SeedPatientAsync(ApplicationsDbContext context)
    {
        if (!await context.Patients.AnyAsync())
        {
            await context.Patients.AddRangeAsync(InitialData.Patients);
            await context.SaveChangesAsync();
        }
    }

   

    private static async Task ClearDataAsync(ApplicationsDbContext context)
    {
        // Clear all data from tables
        context.Patients.RemoveRange(context.Patients);
        

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
