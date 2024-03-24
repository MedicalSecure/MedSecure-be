
namespace Diet.API.Endpoints.Diet;

//- Accepts pagination parameters.
//- Constructs a GetDietsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetDietsRequest(PaginationRequest PaginationRequest);
public record GetDietsResponse(PaginatedResult<DietDto> Diets);

public class GetDiets : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/diets", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetDietsQuery(request));

            var response = result.Adapt<GetDietsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDiets")
        .Produces<GetDietsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Diets")
        .WithDescription("Get Diets");
    }
}