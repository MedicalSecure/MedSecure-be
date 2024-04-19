using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace Sensor.Infrastructure.ExternalServices;

public class ThingSpeakService: IThingSpeakService
{
        private readonly HttpClient _httpClient;

        public ThingSpeakService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    public async Task<ThingSpeakDataResponse> GetSensorDataAsync()
    {
        var response = await _httpClient.GetAsync("https://api.thingspeak.com/channels/2445450/feeds.json");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<ThingSpeakDataResponse>();
    }
}



