namespace Diet.Domain.Models;

public class MealItem: Aggregate<MealItemId>
{
    public MealId MealId { get; set; } = default!;
    public FoodId FoodId { get; set; } = default!;
    public MealCategory MealCategory { get; set; } = default!;

    public MealItem(MealId mealId, FoodId foodId, MealCategory mealCategory)
    {
        Id = MealItemId.Of(Guid.NewGuid());
        MealId = mealId;
        FoodId = foodId;
        MealCategory = mealCategory;
    }
}
