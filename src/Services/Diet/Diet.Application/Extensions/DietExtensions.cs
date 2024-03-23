
namespace Diet.Application.Extensions;

public static partial class DietExtensions
{
    public static IEnumerable<DietDto> ToDietDto(this IEnumerable<Domain.Models.Diet> diets)
    {
        return diets.Select(d => new DietDto(
         Id: d.Id.Value,
                 PatientId: d.PatientId.Value,
                 DietType: d.DietType,
                 StartDate: d.StartDate,
                 EndDate: d.EndDate,
                 Meals: d.Meals.Select(m => new MealDto(
                     m.Id.Value,
                     m.DietId.Value,
                     m.Name,
                     m.MealType,
                     m.MealItems.Select(mi => new MealItemDto(
                         Id: mi.Id.Value,
                         MealId: mi.MealId.Value,
                         FoodId: mi.FoodId.Value,
                         MealCategory: mi.MealCategory)).ToList()
                 )).ToList()));
    }
}
