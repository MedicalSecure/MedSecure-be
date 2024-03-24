
namespace Waste.API.Endpoints.Product;

//- Accepts a CreateProductRequest object.
//- Maps the request to a CreateProductCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created product's ID.

public record CreateProductRequest(ProductDto Product);
public record CreateProductResponse(string Id);

public class CreateProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
