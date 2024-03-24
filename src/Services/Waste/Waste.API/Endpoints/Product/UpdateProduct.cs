
namespace Waste.API.Endpoints.Product;

//- Accepts an UpdateProductRequest.
//- Maps the request to an UpdateProductCommand.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

public record UpdateProductRequest(ProductDto Product);
public record UpdateProductResponse(bool IsSuccess);

public class UpdateProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProductResponse>();

            if (response.IsSuccess)
            {
                return Results.Ok("Product updated successfully");
            }
            else
            {
                return Results.NotFound("Product not found");
            }
        })
        .WithName("UpdateProduct")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}
