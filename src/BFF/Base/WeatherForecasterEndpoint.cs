using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Microsoft.AspNetCore.Routing;

internal static class WeatherForecasterEndpoint
{
    internal static async Task<IEnumerable<WeatherForecast>> MapWeatherForecaster(this IEndpointRouteBuilder endpoints, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        var group = endpoints.MapGroup("");

        group.MapGet("/weather-forecast", async context =>
        {
            var httpContext = httpContextAccessor.HttpContext ??
                throw new InvalidOperationException("No HttpContext available from the IHttpContextAccessor!");

            var accessToken = await httpContext.GetTokenAsync("access_token") ??
                throw new InvalidOperationException("No access_token was saved");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/api/WeatherForecast/sahara");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            // Make the HTTP GET requests to fetch weather forecast data
            using var response = await httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            var weatherForecasts = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();
            if (weatherForecasts == null)
            {
                throw new IOException("No weather forecast!");
            }
        }).AllowAnonymous();

        // Return a default value when the endpoint is invoked
        return Enumerable.Empty<WeatherForecast>();
    }
}


