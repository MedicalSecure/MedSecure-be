namespace Medication.API.Endpoints.Dosage;


//- Accepts a CreateDosageRequest object.
//- Maps the request to a CreateDosageCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created dosage's ID.

public record CreateDosageRequest(List<DosageDto> Dosages);
public record CreateDosageResponse(List<Guid> IDs);

public class CreateDosage : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/dosages", async (CreateDosageRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateDosageCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateDosageResponse>();

            return Results.Created($"/api/v1/dosages/{response.IDs}", response);
        })
        .WithName("CreateDosage")
        .Produces<CreateDosageResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Dosage")
        .WithDescription("Create Dosage");
    }
}
