
namespace Diet.Application.Extensions
{
    public static partial class DietExtensions
    {
        public static IEnumerable<DietDto> ToDietDto(this IEnumerable<Domain.Models.Diet> diets)
        {
            return diets.OrderBy(d => d.DietType)
                        .Select(d => new DietDto(
                            Id: d.Id.Value,
                            PatientId: d.PatientId.Value,
                            DietType: d.DietType,
                            StartDate: d.StartDate,
                            EndDate: d.EndDate,
                            Meals: d.Meals.OrderBy(m => m.MealType)
                                         .Select(m => new MealDto(
                                             Id: m.Id.Value,
                                             DietId: m.DietId.Value,
                                             Name: m.Name,
                                             MealType: m.MealType,
                                             Foods: m.Foods.Select(mi => new FoodDto(
                                                 Id: mi.Id.Value,
                                                 MealId: mi.MealId.Value,
                                                 Name: mi.Name,
                                                 Calories: mi.Calories,
                                                 Description: mi.Description,
                                                 FoodCategory: mi.FoodCategory
                                             )).ToList()
                                         )
                                         ).ToList()
                        ));
        }
    }
}
