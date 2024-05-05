namespace Pharmalink.API.Endpoints.Dosage;

//- Accepts pagination parameters.
//- Constructs a GetDosagesQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetDosagesRequest(PaginationRequest PaginationRequest);
public record GetDosagesResponse(PaginatedResult<DosageDto> Dosages);

public class GetDosages : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/dosages", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetDosagesQuery(paginationRequest));

            var response = result.Adapt<GetDosagesResponse>();

            return Results.Ok(response);
        })
        .WithName("GetDosages")
        .Produces<GetDosagesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Dosages")
        .WithDescription("Get Dosages");
    }
}
