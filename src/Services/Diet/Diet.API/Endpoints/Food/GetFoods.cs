
namespace Diet.API.Endpoints
{
    //- Accepts pagination parameters.
    //- Constructs a GetFoodsQuery with these parameters.
    //- Retrieves the data and returns it in a paginated format.

    //public record GetFoodsRequest(PaginationRequest PaginationRequest);
    public record GetFoodsResponse(PaginatedResult<FoodDto> Foods);

    public class GetFoods : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/foods", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetFoodsQuery(paginationRequest));

                var response = result.Adapt<GetFoodsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetFoods")
            .Produces<GetFoodsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Foods")
            .WithDescription("Get Foods");
        }
    }
}