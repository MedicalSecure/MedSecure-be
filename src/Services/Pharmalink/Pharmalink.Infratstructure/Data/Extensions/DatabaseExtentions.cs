namespace Pharmalink.Infratstructure.Data.Extensions;

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

        await SeedDosageAsync(context);

        await SeedMedicationAsync(context);

    }

    private static async Task SeedDosageAsync(ApplicationDbContext context)
    {
        if (!await context.Dosages.AnyAsync())
        {
            await context.Dosages.AddRangeAsync(InitialData.Dosages);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedMedicationAsync(ApplicationDbContext context)
    {
        if (!await context.Medications.AnyAsync())
        {
            await context.Medications.AddRangeAsync(InitialData.Medications);
            await context.SaveChangesAsync();
        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables
        context.Medications.RemoveRange(context.Medications);

        context.Dosages.RemoveRange(context.Dosages);

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}
