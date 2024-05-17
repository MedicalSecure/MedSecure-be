//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensor.Application.Sensors.Commands.CreateSensor;
//public record CreateSensorCommand(SensorDto Sensor) : ICommand<CreateSensorResult>;
//public record CreateSensorResult(Guid Id);

//public class CreateSensorCommandValidator : AbstractValidator<CreateSensorCommand>
//{
//    public CreateSensorCommandValidator()
//    {
//        RuleFor(x => x.Sensor.Value).NotEmpty().WithMessage("Sensor.Value is required");
//        RuleFor(x => x.Sensor.SensorType).NotEmpty().WithMessage("Sensor.SensorType is required");
//        RuleFor(x => x.Sensor.Location).NotEmpty().WithMessage("Sensor.Location is required");
//        RuleFor(x => x.Sensor.Timestamp).NotEmpty().WithMessage("Sensor.Timestamp is required");
//    }
//}

