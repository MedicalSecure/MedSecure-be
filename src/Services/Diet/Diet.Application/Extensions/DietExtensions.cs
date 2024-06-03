
using System.Linq;

namespace Diet.Application.Extensions
{
    public static partial class DietExtensions
    {
        public static IEnumerable<DietDto> ToDietDto(this IEnumerable<Domain.Models.Diet> diets)
        {
            return diets.OrderBy(d => d.DietType)
                        .Select(d => new DietDto(
                            Id: d.Id.Value,
                            Prescription: d.Prescription.ToSimplePrescriptionDto(),
                            DietType: d.DietType,
                            StartDate: d.StartDate,
                            EndDate: d.EndDate,
                            Meals: d.DailyMeals.ToDailyMealDto().ToList(),
                            Label: d.Label 
                        )).ToList();
        }


        public static IEnumerable<DailyMealDto> ToDailyMealDto(this IEnumerable<Domain.Models.DailyMeal> dailyMeals)
        {
            return dailyMeals.Select(dm => new DailyMealDto(
                Id: dm.Id.Value,
                Meals: dm.Meals.Select(m => new MealDto(
                    Id: m.Id.Value,
                    Name: m.Name,
                    MealType: m.MealType,
                    Foods: m.Foods.Select(f => new FoodDto(
                        Id: f.Id.Value,
                        MealId: m.Id.Value,
                        Name: f.Name,
                        Calories: f.Calories,
                        Description: f.Description,
                        FoodCategory: f.FoodCategory
                    )).ToList(),
                    Comments: dm.Comments.ToSimpleCommentDto().ToList()

                )).ToList(),
                DietDate: dm.DietDate

            )).ToList();
        }
    }
}
