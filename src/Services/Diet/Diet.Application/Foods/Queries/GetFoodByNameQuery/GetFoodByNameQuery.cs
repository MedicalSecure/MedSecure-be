
namespace Diet.Application.Foods.Queries.GetFoodByNameQuery
{
    public record GetFoodByNameQuery(string name) : IQuery<GetFoodByNameResult>;

    public record GetFoodByNameResult(IEnumerable<FoodDto> Foods);
   
}
