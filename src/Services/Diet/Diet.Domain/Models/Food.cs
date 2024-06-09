
namespace Diet.Domain.Models;

public class Food : Aggregate<FoodId>
{
    public string? Name { get; set; } = default!;
    public decimal? Calories { get; set; } 
    public string? Description { get; set; } = default!;
    public FoodCategory? FoodCategory { get; set; } = default!;

    public MealId? MealId { get; set; } = default!;

    public static Food Create(FoodId id , string? name, decimal? calories, string? description, FoodCategory? foodCategory)
    {
        var food = new Food()
        {
            Id = id,
            Name = name,
            Calories = calories,
            Description = description,
            FoodCategory = foodCategory
        };

        food.AddDomainEvent(new FoodCreatedEvent(food));
        return food;
    }

    public void Update(string? name, decimal? calories, string? description, FoodCategory? foodCategory)
    {
        Name = name;
        Calories = calories;
        Description = description;
        FoodCategory = foodCategory;

        AddDomainEvent(new FoodUpdatedEvent(this));
    }
}