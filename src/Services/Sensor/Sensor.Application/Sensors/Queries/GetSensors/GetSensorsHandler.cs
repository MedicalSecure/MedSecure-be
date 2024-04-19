using Sensor.Application.Dtos;
using Sensor.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sensor.Application.Sensors.Queries.GetSensors;

public class GetSensorsHandler(IApplicationDbContext dbContext , IThingSpeakService thingSpeakService)
    : IQueryHandler<GetSensorsQuery, GetSensorsResult>
{
    public async Task<GetSensorsResult> Handle(GetSensorsQuery query, CancellationToken cancellationToken)
    {
        // get sensors with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        // Retrieve sensors from ThingSpeak
        var thingSpeakData = await thingSpeakService.GetSensorDataAsync();
        //Extract feeds from thingspeakdataresponse
        var feeds = thingSpeakData.Feeds;
        var sensorDataTemperature = feeds.Select(feed => feed.Field1).ToList();
        var sensorDataHumidity = feeds.Select(feed => feed.Field2).ToList();
        var sensorDataElectricity = feeds.Select(feed => feed.Field3).ToList();
        var sensorDataLuminosity = feeds.Select(feed => feed.Field4).ToList();

        // Create Sensor objects from the retrieved data and save to database
        foreach (var data in sensorDataTemperature)
        {
            var sensortemperature = Domain.Models.Sensor.Create(
            id: SensorId.Of(Guid.NewGuid()), // Provide an appropriate sensor ID
                value: data,
                sensorType: SensorType.Temperature, // Set the correct sensor type
                location: Location.Pharmacy, // Provide appropriate location information
                timestamp: DateTime.Now // Set the correct timestamp
            );

            dbContext.Sensors.Add(sensortemperature);
        }
        foreach (var data in sensorDataHumidity)
        {
            var sensorhumidity = Domain.Models.Sensor.Create(
            id: SensorId.Of(Guid.NewGuid()), // Provide an appropriate sensor ID
                value: data,
                sensorType: SensorType.Humidity, // Set the correct sensor type
                location: Location.Pharmacy, // Provide appropriate location information
                timestamp: DateTime.Now // Set the correct timestamp
            );

            dbContext.Sensors.Add(sensorhumidity);
        }
        foreach (var data in sensorDataElectricity)
        {
            var sensorelectricity = Domain.Models.Sensor.Create(
            id: SensorId.Of(Guid.NewGuid()), // Provide an appropriate sensor ID
                value: data,
                sensorType: SensorType.Electricity, // Set the correct sensor type
                location: Location.Pharmacy, // Provide appropriate location information
                timestamp: DateTime.Now // Set the correct timestamp
            );

            dbContext.Sensors.Add(sensorelectricity);
        }
        foreach (var data in sensorDataLuminosity)
        {
            var sensorluminosity = Domain.Models.Sensor.Create(
            id: SensorId.Of(Guid.NewGuid()), // Provide an appropriate sensor ID
                value: data,
                sensorType: SensorType.Luminosity, // Set the correct sensor type
                location: Location.Pharmacy, // Provide appropriate location information
                timestamp: DateTime.Now // Set the correct timestamp
            );

            dbContext.Sensors.Add(sensorluminosity);
        }
        await dbContext.SaveChangesAsync(cancellationToken);

        var totalCount = await dbContext.Sensors.LongCountAsync(cancellationToken);
        var sensors = await dbContext.Sensors
                   .OrderBy(o => o.SensorType)
                   .Skip(pageSize * pageIndex)
                   .Take(pageSize)
                   .ToListAsync(cancellationToken);

        return new GetSensorsResult(
            new PaginatedResult<SensorDto>(
                pageIndex,
                pageSize,
                totalCount,
               sensors.ToSensorDto()));
    }
}
