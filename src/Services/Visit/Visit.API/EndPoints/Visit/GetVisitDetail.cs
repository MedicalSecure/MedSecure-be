namespace Visit.API.EndPoints.Visit;

public record GetVisitDetailResponse(IEnumerable<VisitDto> Visits);

public class GetVisitDetail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/visits/{Id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new GetVisitDetailQuery(Id));

            var response = result.Adapt<GetVisitDetailResponse>();

            return Results.Ok(response);
        })
        .WithName("GetVisitDetail")
        .Produces<GetVisitDetailResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Visit Detail")
        .WithDescription("Get Visit Detail");
    }
}
