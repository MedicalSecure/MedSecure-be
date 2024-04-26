
namespace Registration.Infrastructure.Data.Extensions;

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

        await SeedPatientAsync(context);
        
    }

    private static async Task SeedPatientAsync(ApplicationDbContext context)
    {
        if (!await context.Registers.AnyAsync())
        {
            await context.Registers.AddRangeAsync(InitialData.Registers);
            await context.SaveChangesAsync();
        }
    }

   

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Registers.RemoveRange(context.Registers);
        

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
