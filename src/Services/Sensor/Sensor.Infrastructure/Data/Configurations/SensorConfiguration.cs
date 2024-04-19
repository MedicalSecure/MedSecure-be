using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sensor.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Data.Configurations;

public  class SensorConfiguration :IEntityTypeConfiguration<Domain.Models.Sensor>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Sensor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasConversion(sensorId => sensorId.Value,
            dbId => SensorId.Of(dbId));

        builder.Property(d => d.Value).IsRequired();        

        builder.Property(d => d.SensorType).HasDefaultValue(SensorType.Temperature).
           HasConversion(
           dt => dt.ToString(),
           sensorType => (SensorType)Enum.Parse(typeof(SensorType), sensorType));

        builder.Property(d => d.Location).
           HasConversion(
           dt => dt.ToString(),
           location => (Location)Enum.Parse(typeof(Location), location));
        
        builder.Property(i=>i.Timestamp).IsRequired();

    }
}
