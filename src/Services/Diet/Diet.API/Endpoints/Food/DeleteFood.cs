
namespace Diet.API.Endpoints.Food;

//- Accepts a food ID as a parameter.
//- Constructs a DeleteFoodCommand with the food ID.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

//public class DeleteFood : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapDelete("/foods/{foodId}", async (string foodId, ISender sender) =>
//        {
//            var result = await sender.Send(new DeleteFoodCommand(foodId));

//            if (result)
//            {
//                return Results.Ok("Food deleted successfully");
//            }
//            else
//            {
//                return Results.NotFound("Food not found");
//            }
//        })
//        .WithName("DeleteFood")
//        .Produces(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound)
//        .WithSummary("Delete Food")
//        .WithDescription("Delete Food by ID");
//    }
//}
