namespace UnitCare.API.Endpoints.Equipment;

public record GetEquipmentByNameRequest(string EquipmentName);
public record GetEquipmentByNameResponse(EquipmentDto Equipment);

public class GetEquipmentByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/equipments/{equipmentName}", async (string equipmentName, ISender sender) =>
        {
            var result = await sender.Send(new GetEquipmentByNameQuery(equipmentName));

            var response = result.Adapt<GetEquipmentByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetEquipmentByName")
        .Produces<GetEquipmentByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Equipment By Name")
        .WithDescription("Get Equipment By Name");
    }
}
