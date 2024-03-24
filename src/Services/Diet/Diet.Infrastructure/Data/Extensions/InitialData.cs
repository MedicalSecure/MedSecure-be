

using Diet.Domain.Models;

namespace Diet.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        /// <summary>
        /// Retrieves a collection of patients with their details.
        /// </summary>
        public static IEnumerable<Patient> Patients
        {
            get
            {
                try
                {
                    return new List<Patient>
                    {
                        // Create Patient instances
                        Patient.Create(
                            id: PatientId.Of(new Guid(patientId)),
                            firstName: "Alice",
                            lastName: "Smith",
                            dateOfBirth: new DateTime(2002, 02, 22),
                            gender: Gender.Female),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        public static IEnumerable<Domain.Models.Diet> Diets
        {
            get
            {
                try
                {
                    // Create the diet instance
                    var diet = Domain.Models.Diet.Create(
                        id: DietId.Of(Guid.NewGuid()),
                        patientId: PatientId.Of(new Guid(patientId)),
                        startDate: DateTime.Now,
                        endDate: DateTime.Now.AddDays(15),
                        dietType: DietType.Normal);

                    // Create meals for each MealType
                    var breakfastMeal = Meal.Create(MealId.Of(Guid.NewGuid()), diet.Id, "Breakfast Meal", MealType.Breakfast);
                    var lunchMeal = Meal.Create(MealId.Of(Guid.NewGuid()), diet.Id, "Lunch Meal", MealType.Lunch);
                    var dinnerMeal = Meal.Create(MealId.Of(Guid.NewGuid()), diet.Id, "Dinner Meal", MealType.Dinner);
                    var snackMeal = Meal.Create(MealId.Of(Guid.NewGuid()), diet.Id, "Snack Meal", MealType.Snack);

                    // Create foods for each meal
                    var breakfastFoods = new List<Food>
            {
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: breakfastMeal.Id,
                    name: "Oatmeal",
                    calories: 150.0m,
                    description: "Healthy breakfast made with oats.",
                    foodCategory: FoodCategory.Breads),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: breakfastMeal.Id,
                    name: "Scrambled Eggs",
                    calories: 200.0m,
                    description: "Fluffy scrambled eggs seasoned to perfection.",
                    foodCategory: FoodCategory.MainCourses),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: breakfastMeal.Id,
                    name: "Fresh Fruit Salad",
                    calories: 100.0m,
                    description: "Assorted fresh fruits cut into bite-sized pieces.",
                    foodCategory: FoodCategory.Desserts)
            };

                    var lunchFoods = new List<Food>
            {
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: lunchMeal.Id,
                    name: "Grilled Chicken Sandwich",
                    calories: 350.0m,
                    description: "Juicy grilled chicken breast served on whole grain bread.",
                    foodCategory: FoodCategory.MainCourses),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: lunchMeal.Id,
                    name: "Caesar Salad",
                    calories: 200.0m,
                    description: "Classic salad made with romaine lettuce, croutons, and Caesar dressing.",
                    foodCategory: FoodCategory.VegetableGarnish),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: lunchMeal.Id,
                    name: "Iced Tea",
                    calories: 50.0m,
                    description: "Refreshing tea served cold with ice cubes.",
                    foodCategory: FoodCategory.Beverages)
            };

                    var dinnerFoods = new List<Food>
            {
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: dinnerMeal.Id,
                    name: "Salmon Fillet",
                    calories: 300.0m,
                    description: "Delicious salmon fillet seasoned and baked to perfection.",
                    foodCategory: FoodCategory.MainCourses),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: dinnerMeal.Id,
                    name: "Steamed Vegetables",
                    calories: 100.0m,
                    description: "Assorted vegetables steamed until tender.",
                    foodCategory: FoodCategory.VegetableGarnish),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: dinnerMeal.Id,
                    name: "Chocolate Cake",
                    calories: 400.0m,
                    description: "Rich chocolate cake topped with chocolate frosting.",
                    foodCategory: FoodCategory.Desserts)
            };

                    var snackFoods = new List<Food>
            {
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: snackMeal.Id,
                    name: "Greek Yogurt",
                    calories: 150.0m,
                    description: "Creamy Greek yogurt served with honey and nuts.",
                    foodCategory: FoodCategory.Desserts),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: snackMeal.Id,
                    name: "Mixed Nuts",
                    calories: 200.0m,
                    description: "Assorted nuts including almonds, walnuts, and cashews.",
                    foodCategory: FoodCategory.Breads),
                Food.Create(
                    id: FoodId.Of(Guid.NewGuid()),
                    mealId: snackMeal.Id,
                    name: "Vegetable Sticks",
                    calories: 50.0m,
                    description: "Assorted vegetable sticks served with hummus.",
                    foodCategory: FoodCategory.VegetableGarnish)
            };

                    // Add foods to respective meals
                    foreach (var food in breakfastFoods)
                        breakfastMeal.AddFood(food);

                    foreach (var food in lunchFoods)
                        lunchMeal.AddFood(food);

                    foreach (var food in dinnerFoods)
                        dinnerMeal.AddFood(food);

                    foreach (var food in snackFoods)
                        snackMeal.AddFood(food);

                    // Add meals to diet
                    diet.AddMeal(breakfastMeal);
                    diet.AddMeal(lunchMeal);
                    diet.AddMeal(dinnerMeal);
                    diet.AddMeal(snackMeal);

                    return new List<Domain.Models.Diet> { diet };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Diet), ex.Message);
                }
            }
        }



    }
}
