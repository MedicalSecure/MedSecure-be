using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Dtos
{
    public record DispensesDTO(Guid Id,
                Guid PosologyId,
                int Hour,
                Dose? BeforeMeal,
                Dose? AfterMeal);
}