using Sensor.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Sensors.Commands.CreateSensor;

public class CreateSensorHandler(IApplicationDbContext dbContext, IThingSpeakService thingSpeakService) : ICommandHandler<CreateSensorCommand, CreateSensorResult>
{

    public async Task<CreateSensorResult> Handle(CreateSensorCommand command, CancellationToken cancellationToken)
    {

        // create Sensor entity from command object
        // save to database
        // return result

        var sensor = CreateNewSensor(command.Sensor);
        dbContext.Sensors.Add(sensor);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new CreateSensorResult(sensor.Id.Value);

    }

    private static Domain.Models.Sensor CreateNewSensor(SensorDto sensorDto)
    {
        var newSensor = Domain.Models.Sensor.Create(
            id: SensorId.Of(Guid.NewGuid()),
            value: sensorDto.Value,
            sensorType: sensorDto.SensorType,
            location: sensorDto.Location,
            timestamp: sensorDto.Timestamp);


        return newSensor;
    }


}

