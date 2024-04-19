using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Models;

public class Sensor :Aggregate<SensorId>
{
    public string Value { get; set; } = default!;
    public SensorType SensorType { get; set; } = default!;
    public Location Location { get; set; } = default!;
    public DateTime Timestamp { get; set; } = default!;

    public static Sensor Create(SensorId id, string value, SensorType sensorType, Location location, DateTime timestamp)
    {
        var sensor = new Sensor();
        {
            sensor.Id = id;
            sensor.Value = value;
            sensor.SensorType = sensorType;
            sensor.Location = location;
            sensor.Timestamp=timestamp;
           
        }
        sensor.AddDomainEvent(new SensorCreatedEvent(sensor));
        return sensor;
    }



}
