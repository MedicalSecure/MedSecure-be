using Sensor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Sensor.Application.Dtos;

public record SensorDto (Guid Id, string Value, SensorType SensorType, Location Location, DateTime Timestamp);


