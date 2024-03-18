
namespace Diet.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId1 = "7506213d-3b5f-4498-b35c-9169a600ff10";
        private static readonly string patientId2 = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";

        private static readonly string dietId1 = "f3c58f4e-4e49-4180-ba4c-0a2e8cddc58c";
        private static readonly string dietId2 = "2b05fc3d-2e2e-4e88-8a91-2dcf3a01c3d1";

        private static readonly string mealId1 = "bb63acb6-3aaf-433d-9784-e5e9a6ad6b06";
        private static readonly string mealId2 = "142f0efe-9e11-4808-a7f6-fcb564908772";

        private static readonly string mealItemId1 = "05d3a746-fb2c-4d7a-9861-103d9e112637";
        private static readonly string mealItemId2 = "ce0e148b-9906-45a1-b037-b46ea99ca85a";

        private static readonly string foodId1 = "21ebf15a-11c2-4d62-9e7e-bff531c532d0";
        private static readonly string foodId2 = "27f72f54-0960-4fa8-a947-ac9ffaf30abe";


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
                            id: PatientId.Of(new Guid(patientId1)),
                            firstName: "Rahma",
                            lastName: "Tiss",
                            dateOfBirth: new DateTime(2000, 5, 15),
                            gender: Gender.Female),
                        Patient.Create(
                            id: PatientId.Of(new Guid(patientId2)),
                            firstName: "Assem",
                            lastName: "Toumi",
                            dateOfBirth: new DateTime(2000, 8, 25),
                            gender: Gender.Male)
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves a collection of foods with their details.
        /// </summary>
        public static IEnumerable<Food> Foods
        {
            get
            {
                try
                {
                    return new List<Food>
                    {
                        // Create Food instances
                        Food.Create(
                            id: FoodId.Of(new Guid(foodId1)),
                            name: "Apple",
                            calories: 52.0m,
                            description: "A delicious and nutritious fruit."),
                        Food.Create(
                            id: FoodId.Of(new Guid(foodId2)),
                            name: "Broccoli",
                            calories: 34.0m,
                            description: "A green vegetable high in fiber and vitamins.")
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Food), ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves a collection of diets with their associated meals and foods.
        /// </summary>
        public static IEnumerable<Domain.Models.Diet> Diets
        {
            get
            {
                try
                {
                    // Create the first diet instance
                    var diet1 = Domain.Models.Diet.Create(
                        id: DietId.Of(new Guid(dietId1)),
                        patientId: PatientId.Of(new Guid(patientId1)),
                        startDate: DateTime.Now,
                        endDate: DateTime.Now.AddDays(15),
                        dietType: DietType.Normal);

                    // Create the second diet instance
                    var diet2 = Domain.Models.Diet.Create(
                        id: DietId.Of(new Guid(dietId2)),
                        patientId: PatientId.Of(new Guid(patientId2)),
                        startDate: DateTime.Now,
                        endDate: DateTime.Now.AddDays(15),
                        dietType: DietType.Normal);

                    // Create the first meal and add items
                    var meal1 = Meal.Create(MealId.Of(new Guid(mealId1)), diet1.Id, "Breakfast Meal", MealType.Breakfast);
                    meal1.AddItem(meal1.Id, MealCategory.Desserts, FoodId.Of(new Guid(foodId1)));
                    meal1.AddItem(meal1.Id, MealCategory.Beverages, FoodId.Of(new Guid(foodId2)));

                    // Create the second meal and add items
                    var meal2 = Meal.Create(MealId.Of(new Guid(mealId2)), diet2.Id, "Lunch Meal", MealType.Lunch);
                    meal2.AddItem(meal2.Id, MealCategory.Breads, FoodId.Of(new Guid(foodId1)));
                    meal2.AddItem(meal2.Id, MealCategory.MainCourses, FoodId.Of(new Guid(foodId2)));

                    // Add meals to diets
                    diet1.AddMeal(meal1);
                    diet2.AddMeal(meal2);

                    return new List<Domain.Models.Diet> { diet1, diet2 };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Diet), ex.Message);
                }
            }
        }

    }
}
