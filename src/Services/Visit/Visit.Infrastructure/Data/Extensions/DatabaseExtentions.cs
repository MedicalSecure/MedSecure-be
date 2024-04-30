
namespace Visit.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        // Clear existing data
        await ClearDataAsync(context);
        await SeedVisitDetailsAsync(context);
    }
   
    private static async Task SeedVisitDetailsAsync(ApplicationDbContext context)
    {
        if (!context.Visits.Any())
        {
            await context.Visits.AddRangeAsync(InitialData.Visits);
            await context.SaveChangesAsync();
        }
    }

    // Clear existing data
    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
       // context.Patients.RemoveRange(context.Patients);
        context.Visits.RemoveRange(context.Visits);
     
        // Save changes to the database
        await context.SaveChangesAsync();
    }

  

}
