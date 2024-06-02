namespace UnitCare.API.Endpoints.UnitCare;
public record GetUnitCaresResponse(PaginatedResult<UnitCareDto> UnitCares);

public class GetUnitCares : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/unitCares", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetUnitCaresQuery(request));

            var response = result.Adapt<GetUnitCaresResponse>();

            return Results.Ok(response);
        })
        .WithName("GetUnitCares")
        .Produces<GetUnitCaresResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get UnitCare")
        .WithDescription("Get UnitCare");
    }
}