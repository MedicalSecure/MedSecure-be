

namespace BacPatient.API.Endpoints.BPMdel;

//- Accepts pagination parameters.
//- Constructs a GetDietsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetDietsRequest(PaginationRequest PaginationRequest);
public record GetBPResponse(PaginatedResult<BPModelDto> bp);

public class GetBP : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/bacPatient", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetBacPatientQuery(request));

            var response = result.Adapt<GetBPResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBacPatient")
        .Produces<GetBPResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get BacPatient")
        .WithDescription("Get BacPatient");
    }
}