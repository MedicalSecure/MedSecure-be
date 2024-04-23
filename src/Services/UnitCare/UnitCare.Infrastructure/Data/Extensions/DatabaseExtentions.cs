﻿namespace UnitCare.Infrastructure.Data.Extensions;

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
        await SeedUnitCareWithRoomDetailsAsync(context);
    }



    private static async Task SeedUnitCareWithRoomDetailsAsync(ApplicationDbContext context)
    {
        if (!context.UnitCares.Any())
        {
            await context.UnitCares.AddRangeAsync(InitialData.UnitCares);
            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Equipments.RemoveRange(context.Equipments);
        context.Rooms.RemoveRange(context.Rooms);
        context.UnitCares.RemoveRange(context.UnitCares);

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
