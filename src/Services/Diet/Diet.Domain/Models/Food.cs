
namespace Diet.Domain.Models;

public class Food : Aggregate<FoodId>
{
    public string Name { get; set; } = default!;
    public decimal Calories { get; set; } = default!;
    public string Description { get; set; } = default!;

    public static Food Create(FoodId id, string name, decimal calories, string description)
    {
        var food = new Food()
        {
            Id = id,
            Name = name,
            Calories = calories,
            Description = description,
        };

        food.AddDomainEvent(new FoodCreatedEvent(food));
        return food;
    }

    public void Update(string name, decimal calories, string description)
    {
        Name = name;
        Calories = calories;
        Description = description;

        AddDomainEvent(new FoodUpdatedEvent(this));
    }
}