namespace Pharmalink.API.Endpoints.Medication;

//- Accepts pagination parameters.
//- Constructs a GetMedicationsQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetMedicationsRequest(PaginationRequest PaginationRequest);
public record GetMedicationsResponse(PaginatedResult<MedicationDto> Medications);

public class GetMedications : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/medications", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new Application.Medications.Queries.GetMedications.GetMedicationsQuery(paginationRequest));

            var response = result.Adapt<GetMedicationsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetMedications")
        .Produces<GetMedicationsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medications")
        .WithDescription("Get Medications");
    }
}