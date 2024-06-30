
namespace Diet.Infrastructure.Data.Extensions
{
    internal class InitialData
    {

        public static IEnumerable<Domain.Models.Diet> Diets
        {
            get
            {
                var diets = new List<Domain.Models.Diet>
        {
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.Normal, "Normal Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.Liquid, "Liquid Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.SemiLiquid, "Semi-Liquid Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.Diabetic, "Diabetic Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.NoSalt, "No Salt Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.DiabeticNoSalt, "Diabetic No Salt Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.SemiLiquidDiabetic, "Semi-Liquid Diabetic Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.SemiLiquidNoSalt, "Semi-Liquid No Salt Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.SemiLiquidDiabeticNoSalt, "Semi-Liquid Diabetic No Salt Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.NoResidue, "No Residue Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.BrothYogurtCompote, "Broth Yogurt Compote Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.Puree, "Puree Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.HyperProtein, "Hyper Protein Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.HyperCaloric, "Hyper Caloric Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.HypoCaloric, "Hypo Caloric Diet"),
            Domain.Models.Diet.Create(DietId.Of(Guid.NewGuid()), DietType.TubeFeeding, "Tube Feeding Diet")
        };



                try
                {
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Diet), ex.Message);
                }
                return diets;


            }
        }
        public static IEnumerable<Domain.Models.Food> Foodq
        {
            get
            {


                var food = new List<Domain.Models.Food>
                {
                     Food.Create(FoodId.Of(Guid.NewGuid()), "Salad", 150, "Fresh mixed vegetables", FoodCategory.StartersAndSoups),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Grilled Chicken", 300, "Juicy grilled chicken breast", FoodCategory.MainCourses),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Steamed Broccoli", 50, "Healthy steamed broccoli", FoodCategory.VegetableGarnish),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Orange Juice", 100, "Freshly squeezed orange juice", FoodCategory.Beverages),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Chocolate Cake", 500, "Decadent chocolate cake", FoodCategory.Desserts),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Whole Wheat Bread", 80, "Nutritious whole wheat bread", FoodCategory.Breads),
            Food.Create(FoodId.Of(Guid.NewGuid()), "Mixed Nuts", 200, "Assorted mixed nuts", FoodCategory.Snacks)

                };

                try
                {

                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Food), ex.Message);
                }
                return food;


            }
        }
    
    public static IEnumerable<Domain.Models.Meal> Meals
        {
            get
            {


                var meals = new List<Domain.Models.Meal>
                {
                    Meal.Create(MealId.Of(Guid.NewGuid()),"breakfast",MealType.Breakfast),
                     Meal.Create(MealId.Of(Guid.NewGuid()),"lunch",MealType.Lunch),
                      Meal.Create(MealId.Of(Guid.NewGuid()),"dinner",MealType.Dinner),
                       Meal.Create(MealId.Of(Guid.NewGuid()),"snack",MealType.Snack),

                };

                try
                {

                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Meal), ex.Message);
                }
                return meals;


            }
        }
    }
}
