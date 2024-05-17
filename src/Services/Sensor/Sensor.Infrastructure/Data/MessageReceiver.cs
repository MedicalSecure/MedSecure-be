//using Microsoft.Azure.Devices.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensor.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//public class MessageReceiver
//{
//    public async Task ReceiveAndSaveMessagesAsync()
//    {
//        var connectionString = "HostName=MedIot.azure-devices.net;DeviceId=demodevice;SharedAccessKey=V7wAavdEZ8y+r2I7EUhohPlgnfKqsLDO8AIoTFQty84=";
//        var deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);

//        while (true)
//        {
//            var message = await deviceClient.ReceiveAsync();
//            if (message == null) continue;

//            var messageBody = Encoding.UTF8.GetString(message.GetBytes());
//            var sensorData = JsonSerializer.Deserialize<SensorData>(messageBody);


//            using (var dbContext = new ApplicationDbContext(options))
//            {
//                dbContext.SensorData.Add(sensorData);
//                await dbContext.SaveChangesAsync();
//            }

//            await deviceClient.CompleteAsync(message);
//        }
//    }
//}
