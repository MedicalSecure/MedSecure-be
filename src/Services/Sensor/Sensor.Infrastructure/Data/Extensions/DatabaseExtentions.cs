

namespace Sensor.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var thingSpeakService = scope.ServiceProvider.GetRequiredService<IThingSpeakService>();
        context.Database.MigrateAsync().GetAwaiter().GetResult();
        await SeedAsync(context, thingSpeakService);
    }
    private static async Task SeedAsync(ApplicationDbContext context, IThingSpeakService thingSpeakService)
    {
        

        //clear data
        await ClearDataAsync(context);

        await SeedSensorAsync(context);

        await FetchAndSeedSensorDataAsync(context, thingSpeakService);


    }
    private static async Task ClearDataAsync(ApplicationDbContext context)
    {

        //clear all data from datatbase
        context.Sensors.RemoveRange(context.Sensors);
        //save all changes 
        await context.SaveChangesAsync();

    }

    private static async Task SeedSensorAsync(ApplicationDbContext context)
    {
        if (!context.Sensors.Any())
        {

            await context.Sensors.AddRangeAsync(InitialData.Sensors);
            await context.SaveChangesAsync();
        }

    }
    private static async Task FetchAndSeedSensorDataAsync(ApplicationDbContext context, IThingSpeakService thingSpeakService)
    {
        var thingSpeakData = await thingSpeakService.GetSensorDataAsync();
        var feeds = thingSpeakData.Feeds;

        foreach (var feed in feeds)
        {
            var sensorTemperature = Domain.Models.Sensor.Create(
                id: SensorId.Of(Guid.NewGuid()), 
                value: feed.Field1, 
                sensorType: SensorType.Temperature, 
                location: Location.Pharmacy,
                timestamp: feed.CreatedAt 
            );
            var sensorHumidity = Domain.Models.Sensor.Create(
               id: SensorId.Of(Guid.NewGuid()),
               value: feed.Field2,
               sensorType: SensorType.Humidity,
               location: Location.Pharmacy,
               timestamp: feed.CreatedAt
           );
            var sensorLuminosity = Domain.Models.Sensor.Create(
               id: SensorId.Of(Guid.NewGuid()),
               value: feed.Field4,
               sensorType: SensorType.Luminosity,
               location: Location.Pharmacy,
               timestamp: feed.CreatedAt
           );
            var sensorElectricity = Domain.Models.Sensor.Create(
             id: SensorId.Of(Guid.NewGuid()),
             value: feed.Field3,
             sensorType: SensorType.Electricity,
             location: Location.Pharmacy,
             timestamp: feed.CreatedAt
         );
            context.Sensors.AddRange(sensorElectricity,sensorHumidity,sensorLuminosity,sensorTemperature);
        }

        await context.SaveChangesAsync();
    }

}

