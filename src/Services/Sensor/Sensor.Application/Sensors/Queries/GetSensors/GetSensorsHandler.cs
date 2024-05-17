//using Sensor.Application.Dtos;
//using Sensor.Domain.ValueObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace Sensor.Application.Sensors.Queries.GetSensors;

//public class GetSensorsHandler(IApplicationDbContext dbContext)
//    : IQueryHandler<GetSensorsQuery, GetSensorsResult>
//{
//    public async Task<GetSensorsResult> Handle(GetSensorsQuery query, CancellationToken cancellationToken)
//    {
//        // get sensors with pagination
//        // return result
//        var pageIndex = query.PaginationRequest.PageIndex;
//        var pageSize = query.PaginationRequest.PageSize;


//        var totalCount = await dbContext.Sensors.LongCountAsync(cancellationToken);
//        var sensors = await dbContext.Sensors
//                   .OrderBy(o => o.SensorType)
//                   .Skip(pageSize * pageIndex)
//                   .Take(pageSize)
//                   .ToListAsync(cancellationToken);



//        return new GetSensorsResult(
//            new PaginatedResult<SensorDto>(
//                pageIndex,
//                pageSize,
//                totalCount,
//               sensors.ToSensorDto().ToList()));
//    }
//}
