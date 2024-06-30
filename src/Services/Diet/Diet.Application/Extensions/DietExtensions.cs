
using System.Linq;

namespace Diet.Application.Extensions
{
    public static partial class DietExtensions
    {
        public static IEnumerable<DietDto> ToDietDto(this IEnumerable<Domain.Models.Diet> diets)
        {
            return diets
                 .Select(d => new DietDto(
                     Id: d.Id.Value,
                     Register: d.Register.ToSimpleRegisterDto(),
                     DietType: d.DietType,
                     StartDate: d.StartDate,
                     EndDate: d.EndDate,
                     Meals: d.Meals.ToMealsDto().ToList(),
                     Label: d.Label
                 )).ToList();

        }
            public static IEnumerable<MealDto> ToMealsDto(this IEnumerable<Domain.Models.Meal> meals)
        {
            return meals
             .Select(m => new MealDto(
                 Id: m.Id.Value,
                 Name: m.Name,
                 MealType: m.MealType,
                Foods : m.Foods.ToFoodDto().ToList(),
                 Comments:m.Comments.Select(m=> new SimpleCommentsDto(
                     Id : m.Id.Value,
                     PosologyId: Guid.NewGuid() , 
                     Label  : m.Label ,
                     Content: m.Content )
                 
                 ).ToList()
             )).ToList();

        }
        public static IEnumerable<FoodDto> ToFoodDto(this IEnumerable<Domain.Models.Food> foods)
        {
            return foods.Select(m => new FoodDto(
                  Id: m.Id.Value,
                  Name: m.Name,
                  Calories:m.Calories ,
                  Description:m.Description ,
                  FoodCategory:m.FoodCategory
             )).ToList();

        }
    }
}
