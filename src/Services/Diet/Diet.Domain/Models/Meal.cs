
namespace Diet.Domain.Models;

public class Meal : Aggregate<MealId>
{
    private readonly List<MealItem> _mealItems = new();
    public IReadOnlyList<MealItem> MealItems => _mealItems.AsReadOnly();
    public DietId DietId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public MealType MealType { get; set; } = MealType.Breakfast;

    public Meal(DietId dietId, string name, MealType mealType)
    {
        Id = MealId.Of(Guid.NewGuid());
        DietId = dietId;
        Name = name;
        MealType = mealType;
    }

    public Meal()
    {
    }

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

    public void AddItem(MealId mealId, MealCategory mealCategory, FoodId foodId)
    {
        var mealItem = new MealItem(mealId, foodId, mealCategory);
        _mealItems.Add(mealItem);
    }

    public void RemoveItem(FoodId foodId)
    {
        var mealItem = _mealItems.FirstOrDefault(p => p.FoodId == foodId);
        if (mealItem != null)
        {
            _mealItems.Remove(mealItem);
        }
    }
}
