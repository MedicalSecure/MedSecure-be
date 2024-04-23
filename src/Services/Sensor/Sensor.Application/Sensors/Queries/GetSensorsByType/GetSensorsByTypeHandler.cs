using Sensor.Application.Sensors.Queries.GetSensorsByLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Sensors.Queries.GetSensorsByType;

public class GetSensorsByTypeHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSensorsByTypeQuery, GetSensorsByTypeResult>
{
    public async Task<GetSensorsByTypeResult> Handle(GetSensorsByTypeQuery query, CancellationToken cancellationToken)
    {
        //get sensors by name location

        var sensors = await dbContext.Sensors
                  .AsNoTracking()
             .Where(o => o.SensorType == query.name)
             .ToListAsync(cancellationToken);

        return new GetSensorsByTypeResult(sensors.ToSensorDto());

    }
}
