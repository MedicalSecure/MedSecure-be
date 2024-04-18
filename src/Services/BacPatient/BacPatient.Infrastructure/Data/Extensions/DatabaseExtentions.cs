

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

        // Clear existing data
        await ClearDataAsync(context);
        await SeedRoomsAsync(context);
        await SeedUnitCaresAsync(context);
        await SeedPatientAsync(context);
        await SeedBacPatientAsync(context);

    }


    private static async Task SeedPatientAsync(ApplicationDbContext context)
    {
        if (!await context.Patients.AnyAsync())
        {
            await context.Patients.AddRangeAsync(InitialData.Patients);
            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedRoomsAsync(ApplicationDbContext context)
    {
        if (!await context.Rooms.AnyAsync())
        {
            await context.Rooms.AddRangeAsync(InitialData.Rooms);
            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedUnitCaresAsync(ApplicationDbContext context)
    {
        if (!await context.UnitCares.AnyAsync())
        {
            await context.UnitCares.AddRangeAsync(InitialData.UnitCares);
            await context.SaveChangesAsync();
        }
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
        context.Patients.RemoveRange(context.Patients);
        context.Rooms.RemoveRange(context.Rooms);

        context.UnitCares.RemoveRange(context.UnitCares);

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
