
namespace Waste.API.Endpoints.Waste;

//- Accepts a waste ID as a parameter.
//- Constructs a DeleteWasteCommand with the waste ID.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

//public class DeleteWaste : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapDelete("/wastes/{wasteId}", async (string wasteId, ISender sender) =>
//        {
//            var result = await sender.Send(new DeleteWasteCommand(wasteId));

//            if (result)
//            {
//                return Results.Ok("Waste deleted successfully");
//            }
//            else
//            {
//                return Results.NotFound("Waste not found");
//            }
//        })
//        .WithName("DeleteWaste")
//        .Produces(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound)
//        .WithSummary("Delete Waste")
//        .WithDescription("Delete Waste by ID");
//    }
//}
