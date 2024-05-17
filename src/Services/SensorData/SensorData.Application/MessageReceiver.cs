using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorData.Application
{
    public class MessageReceiver
    {
        public async Task ReceiveAndSaveMessagesAsync()
        {
            var connectionString = "YourIoTHubConnectionString";
            var deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);

            while (true)
            {
                var message = await deviceClient.ReceiveAsync();
                if (message == null) continue;

                var messageBody = Encoding.UTF8.GetString(message.GetBytes());
                var sensorData = JsonSerializer.Deserialize<SensorData>(messageBody);

                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.SensorData.Add(sensorData);
                    await dbContext.SaveChangesAsync();
                }

                await deviceClient.CompleteAsync(message);
            }
        }
    }

}
