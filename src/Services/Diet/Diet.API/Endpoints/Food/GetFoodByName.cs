
namespace Diet.API.Endpoints.Food
{
    //- Accepts a food name as a parameter.
    //- Constructs a GetFoodByNameQuery with the food name.
    //- Retrieves the data and returns it.

    public record GetFoodByNameRequest(string FoodName);
    public record GetFoodByNameResponse(FoodDto Food);

    public class GetFoodByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/foods/{foodName}", async (string foodName, ISender sender) =>
            {
                var result = await sender.Send(new GetFoodByNameQuery(foodName));

                var response = result.Adapt<GetFoodByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("GetFoodByName")
            .Produces<GetFoodByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Food By Name")
            .WithDescription("Get Food By Name");
        }
    }
}