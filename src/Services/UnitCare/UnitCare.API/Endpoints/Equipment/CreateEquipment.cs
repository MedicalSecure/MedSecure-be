namespace UnitCare.API.Endpoints.Equipment;

public record CreateEquipmentRequest(EquipmentDto Equipment);
public record CreateEquipmentResponse(Guid Id);

public class CreateEquipment : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/equipments", async (CreateEquipmentRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateEquipmentCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateEquipmentResponse>();

            return Results.Created($"/equipments/{response.Id}", response);
        })
        .WithName("CreateEquipment")
        .Produces<CreateEquipmentResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Equipment")
        .WithDescription("Create Equipment");
    }
}

