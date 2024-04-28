
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace Waste.API.Endpoints.Waste;

//- Accepts pagination parameters.
//- Constructs a GetWastesQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

public record GetWastesRequest(PaginationRequest PaginationRequest);
public record GetWastesResponse(PaginatedResult<WasteDto> Wastes);

public class GetWastes : ICarterModule
{
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes:Read")]
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/wastes", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetWastesQuery(paginationRequest));

            var response = result.Adapt<GetWastesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetWastes")
        .Produces<GetWastesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Wastes")
        .WithDescription("Get Wastes");
    }
}