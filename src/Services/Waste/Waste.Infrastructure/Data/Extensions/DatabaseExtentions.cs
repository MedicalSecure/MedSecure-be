
namespace Waste.Infrastructure.Data.Extensions;

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

        await SeedRoomsAsync(context);
        await SeedProductsAsync(context);
        await SeedWastesAsync(context);
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Rooms.RemoveRange(context.Rooms);
        context.Wastes.RemoveRange(context.Wastes);
        context.WasteItems.RemoveRange(context.WasteItems);
        context.Products.RemoveRange(context.Products);

        // Save changes to the database
        await context.SaveChangesAsync();
    }

    private static async Task SeedRoomsAsync(ApplicationDbContext context)
    {
        if (!await context.Rooms.AnyAsync())
        {
            await context.Rooms.AddRangeAsync(InitialData.Rooms);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedWastesAsync(ApplicationDbContext context)
    {
        if (!await context.Wastes.AnyAsync())
        {
            await context.Wastes.AddRangeAsync(InitialData.Wastes);
            await context.SaveChangesAsync();
        }
    }
}
