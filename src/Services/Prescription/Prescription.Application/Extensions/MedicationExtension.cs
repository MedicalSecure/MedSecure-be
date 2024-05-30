namespace Prescription.Application.Extensions
{
    public static class MedicationExtensions
    {
        public static IEnumerable<MedicationDTO> ToMedicationDto(this List<Medication?> medications)
        {
            return medications
                .Select(m => m.ToMedicationDto())
                //filter nulls
                .OfType<MedicationDTO>();
        }

        public static MedicationDTO? ToMedicationDto(this Medication? m)
        {
            if (m == null) { return null; }
            return new MedicationDTO(
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
                Price: m.Price);
        }
    }
}