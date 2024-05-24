namespace Medication.Application.Extensions;


public static partial class DrugExtensions
{
    public static IEnumerable<DrugDto> ToDrugDto(this List<Drug> drugs)
    {
        return drugs.Select(m => new DrugDto(
            Id: m.Id.Value,
            Name: m.Name,
            Dosage: m.Dosage,
            Form: m.Form,
            Code: m.Code,
            Unit: m.Unit,
            Description: m.Description,
            ExpiredAt: m.ExpiredAt,
            Stock: m.Stock,
            AvailableStock: m.AvailableStock,
            AlertStock: m.AlertStock,
            AvrgStock: m.AvrgStock,
            MinStock: m.MinStock,
            SafetyStock: m.SafetyStock,
            ReservedStock: m.ReservedStock,
            Price: m.Price,
            IsDrugExist: m.IsDrugExist,
            IsDosageValid: m.IsDosageValid));
    }
}
