
namespace Diet.Application.Extensions;

public static partial class FoodExtensions
{
    public static IEnumerable<FoodDto> ToFoodDto(this List<Food> foods)
    {
        return foods.Select(f => new FoodDto(
            Id: f.Id.Value,
            Name: f.Name,
            Calories: f.Calories,
            Description: f.Description));
    }
}