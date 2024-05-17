using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices.Client;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sensor.API.Endpoints.Sensor


{
    [ApiController]
    [Route("[controller]")]
    public class IoTDataController : ControllerBase
    {
        private readonly DeviceClient _deviceClient;

        public IoTDataController(DeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }

        [HttpGet]
        public async Task<IActionResult> ReceiveDataAsync([FromBody] JsonElement data)
        {
            // Traitez les données reçues selon vos besoins
            // Par exemple, vous pouvez les afficher dans la console
            string jsonData = data.ToString();
            System.Console.WriteLine("Received IoT Data: " + jsonData);

            return Ok();
        }
    }
}
