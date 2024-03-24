
namespace Waste.API.Endpoints.Product;

//- Accepts a product name as a parameter.
//- Constructs a GetProductByNameQuery with the product name.
//- Retrieves the data and returns it.

public record GetProductByNameRequest(string ProductName);
public record GetProductByNameResponse(ProductDto Product);

public class GetProductByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{productName}", async (string productName, ISender sender) =>
        {
            var result = await sender.Send(new GetProductyNameQuery(productName));

            var response = result.Adapt<GetProductByNameResponse>();

            if (response.Product != null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Product not found");
            }
        })
        .WithName("GetProductByName")
        .Produces<GetProductByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product By Name")
        .WithDescription("Get Product By Name");
    }
}