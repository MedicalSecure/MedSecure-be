


namespace Diet.Domain.Models;
public class Diet : Aggregate<DietId>
{
    private readonly List<Meal> _meals = new();
    public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();
    public Register? Register { get; set; } = null;
    public DietType? DietType { get; private set; } = null;
    public DateTime? StartDate { get; private set; } = null;
    public DateTime? EndDate { get; private set; } = null;
    public string? Label { get; private set; } = null;

    public static Diet Create(
        DietId id,
        Register? register,
        DateTime? startDate,
        DateTime? endDate,
        DietType? dietType ,
        string? label 
        
        

       )
    {
        var diet = new Diet()
        {
            Id = id,
            Register = register,
            StartDate = startDate,
            EndDate = endDate,
            DietType = dietType,
            Label = label 
        };

        diet.AddDomainEvent(new DietCreatedEvent(diet));

        return diet;
    }
    public static Diet Create(
       DietId id,
       DietType? dietType,
       string? label



      )
    {
        var diet = new Diet()
        {
            Id = id,
            DietType = dietType,
            Label = label
        };

        diet.AddDomainEvent(new DietCreatedEvent(diet));

        return diet;
    }

    public void Update(
        Register? register ,
        DateTime? startDate,
        DateTime? endDate,
        DietType? dietType ,
        string? label
        )
    {
        Register = register;
        StartDate = startDate;
        EndDate = endDate;
        DietType = dietType;
        Label = label; 

        AddDomainEvent(new DietUpdatedEvent(this));
    }

    public void AddMeal(Meal meal)
    {
        if (meal == null)
            throw new ArgumentNullException(nameof(meal));

        _meals.Add(meal);
    }

  
    public void RemoveMeal(MealId mealId)
    {
        var mealToRemove = _meals.FirstOrDefault(meal => meal.Id == mealId);
        if (mealToRemove != null)
        {
            _meals.Remove(mealToRemove);
        }
    }
}
