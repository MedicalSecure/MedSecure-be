namespace Diet.API.Endpoints.Meals
{

 public record GetMealsResponse(PaginatedResult<MealDto> Meals);

    public class GetMeals : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/meals", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new Application.Meals.Queries.GetMealQuery(paginationRequest));

                var response = result.Adapt<GetMealsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetMeal")
            .Produces<GetMealsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Meals")
            .WithDescription("Get Meals");
        }
    }
}