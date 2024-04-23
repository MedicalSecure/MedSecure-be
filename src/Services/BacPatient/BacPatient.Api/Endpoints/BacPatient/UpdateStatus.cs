
using BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;
using BacPatient.Domain.Enums;

namespace BacPatient.API.Endpoints.BPModel;

//- Accepts a UpdateDietRequest.
//- Maps the request to an UpdateDietCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateStatusRequest(Guid Id, StatusBP Status);
public record UpdateStatusResponse(bool IsSuccess);
public class UpdateStatus : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/v1/bacPatient/updateStatus", async (UpdateStatusRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateStatusCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateStatusResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBacPatientStatus")
        .Produces<UpdateStatusResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update BacPatient")
        .WithDescription("Update BacPatient");
    }
}