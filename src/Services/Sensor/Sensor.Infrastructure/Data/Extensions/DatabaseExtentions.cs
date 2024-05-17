

using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
namespace Sensor.Infrastructure.Data.Extensions;

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
        //clear data
        await ClearDataAsync(context);
        // Add mock data
        await SeedSensorAsync(context);
        await ReceiveAndSaveMessagesAsync(context);

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

    private static async Task ReceiveAndSaveMessagesAsync(ApplicationDbContext context)
    {
        var connectionString = "HostName=MedIot.azure-devices.net;DeviceId=demodevice;SharedAccessKey=V7wAavdEZ8y+r2I7EUhohPlgnfKqsLDO8AIoTFQty84=";
        var deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);

        while (true)
        {
            var message = await deviceClient.ReceiveAsync();
            if (message == null) continue;

            var messageBody = Encoding.UTF8.GetString(message.GetBytes());
            var sensorData = JsonSerializer.Deserialize<SensorData>(messageBody);


         
                context.SensorData.Add(sensorData);
                await context.SaveChangesAsync();
         

            await deviceClient.CompleteAsync(message);
        }
    }
}

