
namespace Diet.API.Endpoints
{
    //- Accepts a CreateFoodRequest object.
    //- Maps the request to a CreateFoodCommand.
    //- Uses MediatR to send the command for processing.
    //- Returns a response with the created food's ID.

    public record CreateFoodRequest(FoodDto Food);
    public record CreateFoodResponse(Guid Id);

    public class CreateFood : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/foods", async (CreateFoodRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateFoodCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateFoodResponse>();

                return Results.Created($"/foods/{response.Id}", response);
            })
            .WithName("CreateFood")
            .Produces<CreateFoodResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Food")
            .WithDescription("Create Food");
        }
    }
}
