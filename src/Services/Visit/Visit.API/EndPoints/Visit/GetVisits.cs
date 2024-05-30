namespace Visit.API.EndPoints.Visit;

public record GetVisitsResponse(PaginatedResult<VisitDto> Visits);
public class GetVisits : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapGet("/v1/visits", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetVisitsQuery(request));

            var response = result.Adapt<GetVisitsResponse>();

            return Results.Ok(response);
        })
        .WithName("v1/GetVisits")
        .Produces<GetVisits>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Visits v1")
        .WithDescription("Get Visits v1");
    }
}