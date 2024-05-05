namespace Pharmalink.API.Endpoints.Dosage;

//- Accepts an UpdateDosageRequest.
//- Maps the request to an UpdateDosageCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateDosageRequest(DosageDto Dosage);

public record UpdateDosageResponse(bool IsSuccess);

public class UpdateDosage : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/v1/dosages/{dosageId}",
                async (UpdateDosageRequest request, ISender sender) =>
                {
                    var command = request.Adapt<UpdateDosageCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<UpdateDosageResponse>();

                    return Results.Ok(response);
                }
            )
            .WithName("UpdateDosage")
            .Produces<UpdateDosageResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Dosage")
            .WithDescription("Update Dosage");
    }
}
