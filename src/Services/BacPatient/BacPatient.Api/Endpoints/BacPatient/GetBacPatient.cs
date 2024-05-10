


namespace BacPatient.API.Endpoints.BacPatient;

//- Accepts pagination parameters.
//- Constructs a GetDietsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetDietsRequest(PaginationRequest PaginationRequest);
public record GetBPResponse(PaginatedResult<BacPatientDto> BacPatients);

public class GetBacPatient : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/bacPatient", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {


            var result = await sender.Send(new GetBacPatientQuery(request));

            // Assuming GetBacPatientQuery returns GetBacPatientResult containing PaginatedResult<BacPatientDto>
            var response = new GetBPResponse(result.BacPatients);

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