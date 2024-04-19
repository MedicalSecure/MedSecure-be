using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Extensions;

public static partial class SensorExtension
{
    public static IEnumerable<SensorDto> ToSensorDto(this IEnumerable<Domain.Models.Sensor> sensors)
    {
        return sensors.OrderBy(i => i.SensorType)
            .Select(i => new SensorDto(
                Id: i.Id.Value,
                Value: i.Value,
                SensorType: i.SensorType,
                Location: i.Location,
               Timestamp: i.Timestamp));
    }
}
