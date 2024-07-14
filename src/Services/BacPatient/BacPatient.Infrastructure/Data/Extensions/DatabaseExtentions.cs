

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
            await context.SaveChangesAsync();
                        await context.Registers.AddAsync(InitialData.GetRegisterInitialData());

        }
    }

    private static async Task ClearDataAsync(ApplicationDbContext context)
    {
        await context.SaveChangesAsync();
        context.Patients.RemoveRange(context.Patients);
        context.Registers.RemoveRange(context.Registers);
    }
}
