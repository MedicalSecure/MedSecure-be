namespace UnitCare.API.Endpoints.UnitCare;
public record UpdateUnitCareRequest(UnitCareDto UnitCare);
public record UpdateUnitCareResponse(bool IsSuccess);

public class UpdateUnitCare : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/unitCares", async (UpdateUnitCareRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateUnitCareCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateUnitCareResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateUnitCare")
        .Produces<UpdateUnitCareResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update UnitCare")
        .WithDescription("Update UnitCare");
    }
}