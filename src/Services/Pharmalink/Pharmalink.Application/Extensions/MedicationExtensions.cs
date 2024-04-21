using Pharmalink.Application.Dtos;
using Pharmalink.Domain.Models;

namespace Pharmalink.Application.Extensions;

public static partial class MedicationExtensions
{
    public static IEnumerable<MedicationDto> ToMedciationDto(this List<Medication> medications)
    {
        return medications.Select(m => new MedicationDto(
            Id: m.Id.Value,
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
            Price: m.Price));
    }
}
