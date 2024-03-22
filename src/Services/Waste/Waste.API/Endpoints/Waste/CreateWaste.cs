
namespace Waste.API.Endpoints
{
    //- Accepts a CreateWasteRequest object.
    //- Maps the request to a CreateWasteCommand.
    //- Uses MediatR to send the command for processing.
    //- Returns a response with the created waste's ID.

    public record CreateWasteRequest(WasteDto Waste);
    public record CreateWasteResponse(string Id);

    public class CreateWaste : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/wastes", async (CreateWasteRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateWasteCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateWasteResponse>();

                return Results.Created($"/wastes/{response.Id}", response);
            })
            .WithName("CreateWaste")
            .Produces<CreateWasteResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Waste")
            .WithDescription("Create Waste");
        }
    }
}