namespace Medication.API.Endpoints.Drug;


//- Accepts pagination parameters.
//- Constructs a GetDrugsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

public record GetDrugsResponse(PaginatedResult<DrugDto> Drugs);

public class GetDrugs : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/drugs", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetDrugsQuery(paginationRequest));

            var response = result.Adapt<GetDrugsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDrugs")
        .Produces<GetDrugsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Drugs")
        .WithDescription("Get Drugs");
    }
}
