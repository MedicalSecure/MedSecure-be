
using BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;
using BacPatient.Domain.Enums;

namespace BacPatient.API.Endpoints.BPModel;

//- Accepts a UpdateDietRequest.
//- Maps the request to an UpdateDietCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateBacPatientStatusRequest(Guid Id, StatusBP Status);
public record UpdateBacPatientStatusResponse(bool IsSuccess);
public class UpdateBacPatientStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/bacPatient/updateStatus", async (UpdateBacPatientStatusRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBacPatientStatusCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBacPatientStatusResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBacPatientStatus")
        .Produces<UpdateBacPatientStatusResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update BacPatient")
        .WithDescription("Update BacPatient");
    }
}