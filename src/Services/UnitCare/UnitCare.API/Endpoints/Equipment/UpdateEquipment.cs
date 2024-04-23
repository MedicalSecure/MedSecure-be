namespace UnitCare.API.Endpoints.Equipment;
public record UpdateEquipmentRequest(EquipmentDto Equipment);
public record UpdateEquipmentResponse(bool IsSuccess);

public class UpdateEquipment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/equipments", async (UpdateEquipmentRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateEquipmentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateEquipmentResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateEquipment")
        .Produces<UpdateEquipmentResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Equipment")
        .WithDescription("Update Equipment");
    }
}