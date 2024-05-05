namespace Pharmalink.API.Endpoints.Medication;


//- Accepts a CreateMedicationRequest object.
//- Maps the request to a CreateMedicationCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created medication's ID.

public record CreateMedicationRequest(List<MedicationDto> Medications);
public record CreateMedicationResponse(List<Guid> IDs);

public class CreateMedication : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/medications", async (CreateMedicationRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateMedicationCommand>();
           
            var result = await sender.Send(command);

            var response = result.Adapt<CreateMedicationResponse>();

            return Results.Created($"/api/v1/medications/{response.IDs}", response);
        })
        .WithName("CreateMedicationList")
        .Produces<CreateMedicationResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Medication List")
        .WithDescription("Create Medication List");
    }
}
