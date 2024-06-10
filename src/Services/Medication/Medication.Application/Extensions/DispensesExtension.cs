using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Extensions
{
    public static class DispensesExtension
    {
        public static IEnumerable<DispensesDTO> ToDispensesDto(this IEnumerable<Dispense> dispenses)
        {
            return dispenses.Select(d => d.ToDispenseDto());
        }

        public static DispensesDTO ToDispenseDto(this Dispense dispense)
        {
            return new DispensesDTO(
                Id: dispense.Id.Value,
                PosologyId: dispense.PosologyId?.Value ?? throw new ArgumentNullException("Can't find the posology id from the prescription"),
                Hour: dispense.Hour,
                BeforeMeal: dispense.BeforeMeal != null ? new Dose(dispense.BeforeMeal ?? 0) : null,
                AfterMeal: dispense.BeforeMeal != null ? new Dose(dispense.AfterMeal ?? 0) : null
            );
        }
    }
}