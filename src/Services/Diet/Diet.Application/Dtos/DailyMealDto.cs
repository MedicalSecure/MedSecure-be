using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Dtos
{
   
    public record DailyMealDto(Guid Id, List<MealDto> Meals, DateTime DietDate);

}
