using Medication.API.Endpoints.Drug;
using Medication.Application.Validations.Commands.UpdateValidation;
using Prescription.Domain.ValueObjects;

namespace Medication.API.Endpoints.Validations;

public record UpdateValidationRequest(ValidationDto Validation);
public record UpdateValidationResponse(ValidationDto Validation);
public class UpdateValidation : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/v1/Validations", async (UpdateValidationRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateValidationCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateValidationResponse>();

            return Results.Created($"/api/v1/Validations/{response.Validation.Id}", response);
        })
        .WithName("Update Validation")
        .Produces<UpdateValidationResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Validation")
        .WithDescription("Update Validation");
    }
}
