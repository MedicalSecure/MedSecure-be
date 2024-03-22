
namespace Diet.API.Endpoints
{
    //- Accepts an UpdateFoodRequest.
    //- Maps the request to an UpdateFoodCommand.
    //- Sends the command for processing.
    //- Returns a success or error response based on the outcome.

    public record UpdateFoodRequest(FoodDto Food);
    public record UpdateFoodResponse(bool IsSuccess);

    public class UpdateFood : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/foods", async (UpdateFoodRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateFoodCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateFoodResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateFood")
            .Produces<UpdateFoodResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Food")
            .WithDescription("Update Food");
        }
    }
}