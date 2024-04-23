

namespace Sensor.Infrastructure.Data.Configurations;

public class ThingSpeakService : IThingSpeakService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ThingSpeakService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ThingSpeakDataResponse> GetSensorDataAsync()
    {
        var url = _configuration.GetValue<string>("ExternalService:thingspeakurl");
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<ThingSpeakDataResponse>();
    }


}