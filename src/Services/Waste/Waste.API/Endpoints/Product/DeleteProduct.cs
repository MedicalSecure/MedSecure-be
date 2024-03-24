
namespace Waste.API.Endpoints.Product;

//- Accepts a product ID as a parameter.
//- Constructs a DeleteProductCommand with the product ID.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

//public class DeleteProduct : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapDelete("/products/{productId}", async (string productId, ISender sender) =>
//        {
//            var result = await sender.Send(new DeleteProductCommand(productId));

//            if (result)
//            {
//                return Results.Ok("Product deleted successfully");
//            }
//            else
//            {
//                return Results.NotFound("Product not found");
//            }
//        })
//        .WithName("DeleteProduct")
//        .Produces(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound)
//        .WithSummary("Delete Product")
//        .WithDescription("Delete Product by ID");
//    }
//}
