
namespace Diet.Domain.Models;
public class Diet : Aggregate<DietId>
{
    private readonly List<DailyMeal> _dailyMeals = new();
    public IReadOnlyList<DailyMeal> DailyMeals => _dailyMeals.AsReadOnly();
    public Prescription Prescription { get; private set; } = default!;
    public DietType DietType { get; private set; } = DietType.Normal;
    public DateTime StartDate { get; private set; } = default!;
    public DateTime EndDate { get; private set; } = default!;
    public string Label { get; private set; } = default!;
    public static Diet Create(
        DietId id,
        Prescription prescription,
        DateTime startDate,
        DateTime endDate,
        DietType dietType ,
        string label )
    {
        var diet = new Diet()
        {
            Id = id,
            Prescription = prescription,
            StartDate = startDate,
            EndDate = endDate,
            DietType = dietType,
            Label = label 
        };

        diet.AddDomainEvent(new DietCreatedEvent(diet));

        return diet;
    }

    public void Update(
        Prescription prescription ,
        DateTime startDate,
        DateTime endDate,
        DietType dietType ,
        string label
        )
    {
        Prescription = prescription;
        StartDate = startDate;
        EndDate = endDate;
        DietType = dietType;
        Label = label; 

        AddDomainEvent(new DietUpdatedEvent(this));
    }

    public void AddMeal(DailyMeal meal)
    {
        if (meal == null)
            throw new ArgumentNullException(nameof(meal));

        _dailyMeals.Add(meal);
    }

    public void RemoveMeal(DailyMealId mealId)
    {
        var mealToRemove = _dailyMeals.FirstOrDefault(meal => meal.Id == mealId);
        if (mealToRemove != null)
        {
            _dailyMeals.Remove(mealToRemove);
        }
    }
}
