
namespace Diet.Application.Extensions;

public static partial class FoodExtensions
{
    public static IEnumerable<FoodDto> ToFoodDto(this List<Food> foods)
    {
        return foods.Select(f => new FoodDto(
            Id: f.Id.Value,
            MealId: f.MealId.Value,
            Name: f.Name,
            Calories: f.Calories,
            Description: f.Description,
            FoodCategory: f.FoodCategory
                ));
    }
}