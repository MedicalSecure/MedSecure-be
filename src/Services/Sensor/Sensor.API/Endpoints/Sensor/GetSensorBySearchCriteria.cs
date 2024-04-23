using Microsoft.AspNetCore.Mvc;
using Sensor.Domain.Models;
using System.Net.Http;

namespace Sensor.API.Endpoints.Sensor;
public record GetSensorBySearchCriteriaResponse(IEnumerable<ThingspeakDto> ThingspeakDto);
public class GetSensorBySearchCriteria
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapGet("/v1/sensors", async ([FromQuery] SearchCriteria criteria, ISender sender) =>
        {
            List<ThingspeakDto> searchResults = new List<ThingspeakDto>();

          // searchResults.Add(new ThingspeakDto(Guid.NewGuid(), new Channel(), new List<Feed>()));
            
            // Return the search results
            return Results.Ok(new GetSensorBySearchCriteriaResponse(searchResults));

        });
}
}



//namespace Sensor.API.Endpoints.Sensor;

//public record GetSensorBySearchCriteriaResponse(IEnumerable<ThingspeakDto> ThingspeakDto);
//public class GetSensorBySearchCriteria
//{
//    private readonly HttpClient httpClient;
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {

//        app.MapGet("/v1/sensors", async ([FromQuery] SearchCriteria criteria) =>
//        {
//            // Send a request to a service or another part of the application
//            var searchResults = await FetchSearchResultsAsync(criteria);

//            // Return the search results
//            return Results.Ok(new GetSensorBySearchCriteriaResponse(searchResults));
//        })
//       .WithName("GetSensorByLocation")
//       .Produces<GetSensorBySearchCriteriaResponse>(StatusCodes.Status200OK)
//       .ProducesProblem(StatusCodes.Status400BadRequest)
//       .ProducesProblem(StatusCodes.Status404NotFound)
//       .WithSummary("Get Sensor By Location")
//       .WithDescription("Get Sensor By Location ");
//    }
//    private async Task<IEnumerable<ThingspeakDto>> FetchSearchResultsAsync(SearchCriteria criteria)
//    {
//        // Perform search logic, for example, querying an external API
//        // and retrieving the results
//        // Use HttpClient to send an HTTP request

//        var url = "https://api.thingspeak.com/channels/2445450/feeds.json";
//        var response = await httpClient.GetAsync(url);

//        // Check if the request was successful
//        response.EnsureSuccessStatusCode();

//        // Deserialize the response into a list of ThingspeakDto
//        var searchResults = await response.Content.ReadAsAsync<IEnumerable<ThingspeakDto>>();

//        return searchResults;
//    }

//}



