
namespace Waste.API.Endpoints
{
    //- Accepts pagination parameters.
    //- Constructs a GetProductsQuery with these parameters.
    //- Retrieves the data and returns it in a paginated format.

    //public record GetProductsRequest(PaginationRequest PaginationRequest);
    public record GetProductsResponse(PaginatedResult<ProductDto> Products);

    public class GetProducts : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery(paginationRequest));

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}