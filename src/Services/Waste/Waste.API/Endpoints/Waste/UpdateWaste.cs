
namespace Waste.API.Endpoints.Waste;

//- Accepts an UpdateWasteRequest.
//- Maps the request to an UpdateWasteCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateWasteRequest(WasteDto Waste);
public record UpdateWasteResponse(bool IsSuccess);

public class UpdateWaste : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/wastes", async (UpdateWasteRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateWasteCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateWasteResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateWaste")
        .Produces<UpdateWasteResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Waste")
        .WithDescription("Update Waste");
    }
}