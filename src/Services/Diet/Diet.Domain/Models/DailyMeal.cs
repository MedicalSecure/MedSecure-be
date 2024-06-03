namespace Diet.Domain.Models
{
    public class DailyMeal : Aggregate<DailyMealId>
    {
        private readonly List<Meal> _meals = new();
        public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();

        public DateTime DietDate { get; set; } = DateTime.Now;


        private readonly List<Comment> _comments = new();
        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();
        //for EF 
        public DietId DietId { get; set; }

        public DailyMeal() { }
        public static DailyMeal Create(
            DailyMealId id,
            DateTime dietDate)
        {
            var dailyMeal = new DailyMeal()
            {
                Id = id,
                DietDate = dietDate
            };

            dailyMeal.AddDomainEvent(new DailyMealCreatedEvent(dailyMeal));

            return dailyMeal;
        }

        public void Update(
            DateTime dietDate)
        {
            DietDate = dietDate;
            AddDomainEvent(new DailyMealUpdatedEvent(this));
        }

        public void AddMeal(Meal meal)
        {
            if (meal == null)
                throw new ArgumentNullException(nameof(meal));

            _meals.Add(meal);
        }
        public void AddComments(ICollection<Comment> comments)
        {
            foreach (var comment in comments)
            {
                _comments.Add(comment);
            }
        }
        public void RemoveMeal(MealId mealId)
        {
            var dailyMeal = _meals.FirstOrDefault(p => p.Id == mealId);
            if (dailyMeal != null)
            {
                _meals.Remove(dailyMeal);
            }
        }

    }


  }
