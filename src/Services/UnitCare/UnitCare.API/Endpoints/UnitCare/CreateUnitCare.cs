namespace UnitCare.API.Endpoints.UnitCare;


public record CreateUnitCareRequest(UnitCareDto UnitCare);
public record CreateUnitCareResponse(Guid Id);

public class CreateUnitCare : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/unitCares", async (CreateUnitCareRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateUnitCareCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateUnitCareResponse>();

            return Results.Created($"/unitCares/{response.Id}", response);
        })
        .WithName("CreateUnitCare")
        .Produces<CreateUnitCareResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create UnitCare")
        .WithDescription("Create UnitCare");
    }
}