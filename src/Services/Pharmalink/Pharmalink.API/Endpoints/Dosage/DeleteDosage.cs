namespace Pharmalink.API.Endpoints.Dosage;

//- Accepts a dosage ID as a parameter.
//- Constructs a DeleteDosageCommand with the dosage ID.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.
public record DeleteDosageRequest(Guid Id);
public record DeleteDosageResponse(bool IsSuccess);

public class DeleteDosage : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/v1/dosages/{dosageId}", async (Guid Id, ISender sender) =>
        {
            var command = new DeleteDosageCommand(Id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteDosageResponse>();
            return Results.Ok(response);

        })
        .WithName("DeleteDosage")
        .Produces<DeleteDosageResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Dosage")
        .WithDescription("Delete Dosage");
    }
}
