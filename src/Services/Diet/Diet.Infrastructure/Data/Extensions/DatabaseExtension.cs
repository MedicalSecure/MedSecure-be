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

        await SeedFoodAsync(context);
        await SeedMealsAsync(context);



    }


    private static async Task SeedDietAsync(ApplicationDbContext context)
    {
        if (!context.Diets.Any())
        {
            await context.Diets.AddRangeAsync(InitialData.Diets);

            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedFoodAsync(ApplicationDbContext context)
    {
        if (!context.Foods.Any())
        {
            await context.Foods.AddRangeAsync(InitialData.Foodq);

            await context.SaveChangesAsync();
        }
    }
    private static async Task SeedMealsAsync(ApplicationDbContext context)
    {
        if (!context.Meals.Any())
        {
            await context.Meals.AddRangeAsync(InitialData.Meals);

            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Diets.RemoveRange(context.Diets);
        context.Meals.RemoveRange(context.Meals);
        context.Foods.RemoveRange(context.Foods);
        // Save changes to the database
        await context.SaveChangesAsync();
    }
}