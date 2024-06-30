
namespace Diet.Domain.Models;

public class Meal : Aggregate<MealId>
{
    private readonly List<Food> _foods = new();
    public IReadOnlyList<Food> Foods => _foods.AsReadOnly();
    private readonly List<Comment?> _comments  = new();
    public IReadOnlyList<Comment?> Comments => _comments.AsReadOnly();
    public DietId? DietId { get; set; }  // Foreign key
    public string? Name { get; set; } = default!;
    public MealType? MealType { get; set; }

    public static Meal Create(
        MealId id,
        string name,
        MealType? mealType)
    {
        var meal = new Meal()
        {
            Id = id,
            Name = name,
            MealType = mealType,
        };

        meal.AddDomainEvent(new MealCreatedEvent(meal));

        return meal;
    }

    public void Update(
        string name,
        MealType mealType)
    {
        Name = name;
        MealType = mealType;

        AddDomainEvent(new MealUpdatedEvent(this));
    }

    public void AddFood(Food food)
    {
        if (food == null)
            throw new ArgumentNullException(nameof(food));

        _foods.Add(food);
    }
    public void AddComments(Comment comment)
    {
        if (comment == null)
            throw new ArgumentNullException(nameof(comment));

        _comments.Add(comment);
    }
    public void RemoveComment(CommentId commentId)
    {
        var mealFood = _comments.FirstOrDefault(p => p.Id == commentId);
        if (mealFood != null)
        {
            _comments.Remove(mealFood);
        }
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
