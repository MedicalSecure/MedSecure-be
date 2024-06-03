namespace Diet.Infrastructure.Data.Extensions;

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
        await SeedDietWithMealDetailsAsync(context);
    }

    private static async Task SeedPatientAsync(ApplicationDbContext context)
    {
        if (!await context.Patients.AnyAsync())
        {
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedDietWithMealDetailsAsync(ApplicationDbContext context)
    {
        if (!context.Diets.Any())
        {
            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Patients.RemoveRange(context.Patients);
        context.Foods.RemoveRange(context.Foods);
        context.Meals.RemoveRange(context.Meals);
        context.Diets.RemoveRange(context.Diets);

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}