

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
        await ClearDataAsync(context);
      
        await SeedBacPatientAsync(context);

    }



    private static async Task SeedBacPatientAsync(ApplicationDbContext context)
    {
        if (!context.BacPatients.Any())
        {
            await context.BacPatients.AddRangeAsync(InitialData.BacPatients);
            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        

        context.BacPatients.RemoveRange(context.BacPatients);
        context.Medecines.RemoveRange(context.Medecines);
        context.Posologies.RemoveRange(context.Posologies);



        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
