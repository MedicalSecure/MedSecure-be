namespace Diet.Domain.Models;

public class Diet : Aggregate<DietId>
{
    private readonly List<Meal> _Meals = new();
    public List<Meal> Meals { get; private set; } = default!;
    public PatientId PatientId { get; private set; } = default!;
    public DateTime StartDate { get; private set; } = default!;
    public DateTime EndDate { get; private set; } = default!;
    public DietType DietType { get; private set; } = DietType.Normal;

    public static Diet Create(
        DietId id,
        PatientId patientId,
        DateTime startDate,
        DateTime endDate,
        DietType dietType)
    {
        var diet = new Diet()
        {
            Id = id,
            PatientId = patientId,
            StartDate = startDate,
            EndDate = endDate,
            DietType = dietType,
        };

        diet.AddDomainEvent(new DietCreatedEvent(diet));

        return diet;
    }

    public static Diet Update(
        Diet diet,
        PatientId patientId,
        DateTime startDate,
        DateTime endDate,
        DietType dietType)
    {
        diet.PatientId = patientId;
        diet.StartDate = startDate;
        diet.EndDate = endDate;
        diet.DietType = dietType;

        diet.AddDomainEvent(new DietUpdatedEvent(diet));

        return diet;
    }

    public void AddMeal(string name, MealType mealType, Dictionary<MealComponent, List<string>> components)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(components);

        var meal = new Meal(name, mealType, components);
        _Meals.Add(meal);
    }

    public void RemoveMeal(MealId mealId)
    {
        var mealToRemove = _Meals.FirstOrDefault(meal => meal.MealId == mealId);
        if (mealToRemove != null)
        {
            _Meals.Remove(mealToRemove);
        }
    }
}
