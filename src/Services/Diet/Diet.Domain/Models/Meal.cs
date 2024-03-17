
namespace Diet.Domain.Models;

public class Meal : Aggregate<MealId>
{
    public Meal(string name, MealType mealType, Dictionary<MealComponent, List<string>> components)
    {
        Id = MealId.Of(Guid.NewGuid());
        Name = name;
        MealType = mealType;
        Components = components;
    }
    public string Name { get; set; }
    public MealId MealId { get; set; } = default!;
    public MealType MealType { get; set; } = MealType.Breakfast;
    public Dictionary<MealComponent, List<string>> Components { get; set; }
}