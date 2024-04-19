﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.ValueObjects;

public record SensorId
{
    public Guid Value { get; }
    private SensorId(Guid value)=> Value = value;
    public static SensorId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if(value==Guid.Empty)
        {
            throw new DomainException("SensorId cannot be empty!");
        }
        return new SensorId(value);
    }
}
