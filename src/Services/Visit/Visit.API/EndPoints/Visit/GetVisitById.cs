namespace Visit.API.EndPoints.Visit;
public record GetVisitByIdResponse(IEnumerable<VisitDto> Visits);

public class GetVisitById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/visits/{Id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new GetVisitByIdQuery(Id));

            var response = result.Adapt<GetVisitByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetVisitById")
        .Produces<GetVisitByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Visit ById")
        .WithDescription("Get Visit ById");
    }
}
