using Mapster;
using MediatR;
using Pharmalink.Application.Dtos;
using Pharmalink.Application.Medications.Commands.CreateMedication;

namespace Pharmalink.API.Endpoints.Medication;


//- Accepts a CreateMedicationRequest object.
//- Maps the request to a CreateMedicationCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created food's ID.

public record CreateMedicationRequest(MedicationDto Food);
public record CreateMedicationResponse(Guid Id);

public class CreateMedication : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/foods", async (CreateMedicationRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateMedicationCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateMedicationResponse>();

            return Results.Created($"/medications/{response.Id}", response);
        })
        .WithName("CreateMedication")
        .Produces<CreateMedicationResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Medication")
        .WithDescription("Create Medication");
    }
}
