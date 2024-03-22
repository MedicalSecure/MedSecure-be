
namespace Diet.Application.Diets.Queries.GetFoodByNameQuery
{
    public record GetFoodByNameQuery(string name) : IQuery<GetFoodByNameResult>;

    public record GetFoodByNameResult(IEnumerable<FoodDto> Foods);
   
}
