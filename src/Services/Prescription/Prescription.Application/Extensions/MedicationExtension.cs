using rescription.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Extensions
{
    public static class MedicationExtensions
    {
        public static IEnumerable<MedicationDto> ToMedicationDto(this List<Medication> medications)
        {
            return medications.Select(m => m.ToMedicationDto());
        }

        public static MedicationDto ToMedicationDto(this Medication m)
        {
            return new MedicationDto(
                Id: m.Id,
                Name: m.Name,
                Dosage: m.Dosage,
                Form: m.Form,
                Code: m.Code,
                Unit: m.Unit,
                Description: m.Description,
                ExpiredAt: m.ExpiredAt,
                Stock: m.Stock,
                AlertStock: m.AlertStock,
                AvrgStock: m.AvrgStock,
                MinStock: m.MinStock,
                SafetyStock: m.SafetyStock,
                ReservedStock: m.ReservedStock,
                Price: m.Price);
        }
    }
}