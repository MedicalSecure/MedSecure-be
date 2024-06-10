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

        //await SeedRegisterAsync(context);
    }

    private static async Task SeedRegisterAsync(ApplicationDbContext context)
    {
        if (!await context.Registers.AnyAsync())
        {
            await context.Registers.AddAsync(InitialData.GetRegisterInitialData());
            await context.SaveChangesAsync();
        }
    }

    //private static async Task SeedPatientAsync(ApplicationDbContext context)
    //{
    //    if (!await context.Patients.AnyAsync())
    //    {
    //        await context.Patients.AddRangeAsync(InitialData.Patients);
    //        await context.SaveChangesAsync();
    //    }
    //}
    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        // Clear all data from tables

        context.Patients.RemoveRange(context.Patients);
        context.Histories.RemoveRange(context.Histories);
        context.RiskFactors.RemoveRange(context.RiskFactors);
        context.Tests.RemoveRange(context.Tests);
        context.Registers.RemoveRange(context.Registers);

        // Save changes to the database
        await context.SaveChangesAsync();
    }
}