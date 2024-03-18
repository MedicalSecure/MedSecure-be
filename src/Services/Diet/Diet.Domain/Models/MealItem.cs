
namespace Diet.Domain.Models;

public class MealItem : Aggregate<MealItemId>
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

    public static MealItem Create(MealItemId id , MealId mealId, FoodId foodId, MealCategory mealCategory)
    {
        var mealItem = new MealItem(mealId, foodId, mealCategory)
        {
            Id = id,
        };

        mealItem.AddDomainEvent(new MealItemCreatedEvent(mealItem));

        return mealItem;
    }

    public void Update(MealId mealId, FoodId foodId, MealCategory mealCategory)
    {
        MealId = mealId;
        FoodId = foodId;
        MealCategory = mealCategory;
        
        AddDomainEvent(new MealItemUpdatedEvent(this));
    }
}
