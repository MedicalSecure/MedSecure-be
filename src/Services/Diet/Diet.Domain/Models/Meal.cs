
namespace Diet.Domain.Models;

public class Meal : Aggregate<MealId>
{
    private readonly List<Food> _foods = new();
    public IReadOnlyList<Food> Foods => _foods.AsReadOnly();
    public DietId DietId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public MealType MealType { get; set; } = MealType.Breakfast;

    public static Meal Create(
        MealId id,
        DietId dietId, 
        string name, 
        MealType mealType)
    {
        var meal = new Meal()
        {
            Id = id,
            DietId = dietId,
            Name = name,
            MealType = mealType,
        };

        meal.AddDomainEvent(new MealCreatedEvent(meal));

        return meal;
    }

    public void Update(
        DietId dietId,
        string name,
        MealType mealType)
    {
        Name = name;
        MealType = mealType;
        DietId = dietId;

        AddDomainEvent(new MealUpdatedEvent(this));
    }

    public void AddFood(Food food)
    {
        if (food == null)
            throw new ArgumentNullException(nameof(food));

        _foods.Add(food);
    }

    public void RemoveFood(FoodId foodId)
    {
        var mealFood = _foods.FirstOrDefault(p => p.Id == foodId);
        if (mealFood != null)
        {
            _foods.Remove(mealFood);
        }
    }
}
