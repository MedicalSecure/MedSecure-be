
using BacPatient.Application.BPModels.Commands.UpdateDiet;

namespace BacPatient.API.Endpoints.BPModel;

//- Accepts a UpdateDietRequest.
//- Maps the request to an UpdateDietCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateBacPatientRequest(BPModelDto Diet);
public record UpdateBacPatientResponse(bool IsSuccess);

public class UpdateBP : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/bacpatient", async (UpdateBacPatientRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBPCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateBacPatientResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateBacPatient")
        .Produces<UpdateBacPatientResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update BacPatient")
        .WithDescription("Update BacPatient");
    }
}