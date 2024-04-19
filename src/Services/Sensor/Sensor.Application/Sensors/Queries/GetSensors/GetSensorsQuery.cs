using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Sensors.Queries.GetSensors;

public record GetSensorsQuery(PaginationRequest PaginationRequest)
: IQuery<GetSensorsResult>;
public record GetSensorsResult (PaginatedResult<SensorDto>Sensors);
