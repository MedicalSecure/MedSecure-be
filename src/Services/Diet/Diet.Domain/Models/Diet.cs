namespace Diet.Domain.Models;
public class Diet : Aggregate<DietId>
{
    private readonly List<Meal> _meals = new();
    public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();
    public PatientId PatientId { get; private set; } = default!;
    public DietType DietType { get; private set; } = DietType.Normal;
    public DateTime StartDate { get; private set; } = default!;
    public DateTime EndDate { get; private set; } = default!;

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

    public void Update(
        PatientId patientId,
        DateTime startDate,
        DateTime endDate,
        DietType dietType)
    {
        PatientId = patientId;
        StartDate = startDate;
        EndDate = endDate;
        DietType = dietType;

        AddDomainEvent(new DietUpdatedEvent(this));
    }

    public void AddMeal(DietId dietId, string name, MealType mealType)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        var meal = new Meal(dietId,name,mealType);
        _meals.Add(meal);
    }

    public void RemoveMeal(DietId dietId)
    {
        var mealToRemove = _meals.FirstOrDefault(meal => meal.DietId == dietId);
        if (mealToRemove != null)
        {
            _meals.Remove(mealToRemove);
        }
    }
}
