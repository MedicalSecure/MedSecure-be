
namespace Diet.API.Endpoints.Patient;

//- Accepts pagination parameters.
//- Constructs a GetPatientsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

public record GetPatientsResponse(PaginatedResult<PatientDto> Patients);

public class GetPatients : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/patients", async (HttpContext context, [AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetPatientsQuery(paginationRequest));

            var response = result.Adapt<GetPatientsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetPatients")
        .Produces<GetPatientsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Patients")
        .WithDescription("Get Patients");
    }
}