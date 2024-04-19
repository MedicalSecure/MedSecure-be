using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
 public static async Task InitialiseDatabaseAsync(this WebApplication app)
{
   using var scope= app.Services.CreateScope();
   var context=scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
   context.Database.MigrateAsync().GetAwaiter().GetResult();
   await SeedAsync(context);
}
    private static async Task SeedAsync(ApplicationDbContext context)
    {
        //clear data
        await ClearDataAsync(context);

        await SeedSensorAsync(context);
     

    }
    private static async Task ClearDataAsync (ApplicationDbContext context)
    {

        //clear all data from datatbase
        context.Sensors.RemoveRange(context.Sensors);
        //save all changes 
        await context.SaveChangesAsync();

    }

    private static async Task SeedSensorAsync (ApplicationDbContext context)
    {
        if (!context.Sensors.Any())
        {
            await context.Sensors.AddRangeAsync(InitialData.Sensors);
            await context.SaveChangesAsync();
        }
    }
}
