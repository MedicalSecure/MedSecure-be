

namespace BacPatient.Infrastructure.Data.Extensions;

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
        await SeedDietWithMealDetailsAsync(context);
    }



    private static async Task SeedDietWithMealDetailsAsync(ApplicationDbContext context)
    {
        if (!context.BacPatients.Any())
        {
            await context.BacPatients.AddRangeAsync(InitialData.bPModels);
            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.BacPatients.RemoveRange(context.BacPatients);
 

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
