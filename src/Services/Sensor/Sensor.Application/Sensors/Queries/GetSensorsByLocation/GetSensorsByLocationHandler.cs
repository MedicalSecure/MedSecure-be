using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Sensors.Queries.GetSensorsByLocation;

public class GetSensorsByLocationHandler(IApplicationDbContext dbContext):IQueryHandler<GetSensorsByLocationQuery, GetSensorsByLocationResult>
{
    public async Task<GetSensorsByLocationResult>Handle(GetSensorsByLocationQuery query,CancellationToken cancellationToken)
    {
        //get sensors by name location

        var sensors= await dbContext.Sensors
                  .AsNoTracking()
             .Where(o => o.Location==query.name)
             .ToListAsync(cancellationToken);

        return new GetSensorsByLocationResult(sensors.ToSensorDto());

    }
}
