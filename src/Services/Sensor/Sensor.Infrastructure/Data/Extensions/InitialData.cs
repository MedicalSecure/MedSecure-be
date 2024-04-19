using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Domain.Models.Sensor> Sensors
        {
            get
            {
                try

                {
                    // Créer une instance de capteur de température
                    var temperatureSensor = Domain.Models.Sensor.Create(
                        id: SensorId.Of(Guid.NewGuid()),
                        value: "25%",
                        sensorType: SensorType.Temperature,
                        location: Location.Pharmacy,
                        timestamp: DateTime.Now);

                    // Créer une instance de capteur d'humidité
                    var humiditySensor = Domain.Models.Sensor.Create(
                        id: SensorId.Of(Guid.NewGuid()),
                        value: "50%",
                        sensorType: SensorType.Humidity,
                        location: Location.Pharmacy,
                        timestamp: DateTime.Now);

                    // Créer une instance de capteur d'électricité
                    var electricitySensor = Domain.Models.Sensor.Create(
                        id: SensorId.Of(Guid.NewGuid()),
                        value: "220V",
                        sensorType: SensorType.Electricity,
                        location: Location.Pharmacy,
                        timestamp: DateTime.Now);

                    // Créer une instance de capteur de luminosité
                    var lightSensor = Domain.Models.Sensor.Create(
                        id: SensorId.Of(Guid.NewGuid()),
                        value: "75%",
                        sensorType: SensorType.Luminosity,
                        location: Location.Pharmacy,
                        timestamp: DateTime.Now);

                    // Retourner la liste des capteurs créés
                    return new List<Domain.Models.Sensor> { temperatureSensor, humiditySensor, electricitySensor, lightSensor };

                }
                catch (Exception errur)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Sensor), errur.Message);
                }
            }
        }
    }

}
