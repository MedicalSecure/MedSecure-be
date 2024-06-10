using Prescription.Domain.Entities;

namespace Prescription.Application.Extensions
{
    public static class PrescriptionExtension
    {
        public static IEnumerable<PrescriptionDTO> ToPrescriptionsDto(this IEnumerable<Domain.Entities.Prescription> prescriptions, bool includeRegister = true)
        {
            return prescriptions.Select(p => p.ToPrescriptionDto(includeRegister));
        }

        /*        public static Domain.Entities.Prescription ToPrescription(this PrescriptionDto p)
                {
                    return pres
                }*/

        public static PrescriptionDTO ToPrescriptionDto(this Domain.Entities.Prescription pres, bool includeRegister = false)
        {
            var x = new PrescriptionDTO(
                Id: pres.Id.Value,
                RegisterId: pres.RegisterId.Value,
                DoctorId: pres.DoctorId.Value,
                Symptoms: pres.Symptoms.ToSymptomsDto(),
                Diagnoses: pres.Diagnosis.ToDiagnosisDto(),
                Posologies: pres.Posology.ToPosologiesDto(),
                //Validations: pres.Validations.ToValidationsDto(),
                Validation: pres.Validation?.ToValidationDto(),
                CreatedAt: pres.CreatedAt ?? DateTime.UtcNow,
                Status: pres.Status,
                BedId: pres.BedId?.Value ?? null,
                Diet: pres.Diet?.ToDietForPrescriptionDto() ?? null,
                LastModified: pres.LastModified,
                CreatedBy: pres.CreatedBy,
                LastModifiedBy: pres.LastModifiedBy
            ); ;
            return x;
        }

        public static DietForPrescriptionDTO ToDietForPrescriptionDto(this DietForPrescription diet)
        {
            return new DietForPrescriptionDTO(
                Id: diet.Id.Value,
                StartDate: diet.StartDate.ToDateTime(TimeOnly.MinValue),
                EndDate: diet.EndDate.ToDateTime(TimeOnly.MinValue),
                DietsId: diet.DietsId
            );
        }

        public static IEnumerable<DispensesDTO> ToDispensesDto(this IEnumerable<Dispense> dispenses)
        {
            return dispenses.Select(d => d.ToDispenseDto());
        }

        public static DispensesDTO ToDispenseDto(this Dispense dispense)
        {
            return new DispensesDTO(
                Id: dispense.Id.Value,
                PosologyId: dispense.PosologyId.Value,
                Hour: dispense.Hour,
                BeforeMeal: dispense.BeforeMeal,
                AfterMeal: dispense.AfterMeal
            );
        }

        public static ICollection<PosologyDTO> ToPosologiesDto(this IReadOnlyList<Posology> posologies)
        {
            return posologies.Select(posology => posology.ToPosologyDto()).ToList();
        }

        public static PosologyDTO ToPosologyDto(this Posology posology)
        {
            return new PosologyDTO(
                 Id: posology.Id.Value,
                PrescriptionId: posology.PrescriptionId.Value,
                Medication: posology.Medication?.ToMedicationDto(),
                MedicationId: posology.MedicationId.Value,
                Comments: posology.Comments.Select(c => new CommentsDTO(
                    Id: c.Id.Value,
                    PosologyId: posology.Id.Value,
                    Label: c.Label,
                    Content: c.Content
                )).ToList(),
               Dispenses: posology.Dispenses.Select(d => new DispensesDTO(
                    Id: d.Id.Value,
                    PosologyId: posology.Id.Value,
                    Hour: d.Hour,
                    BeforeMeal: d.BeforeMeal,
                    AfterMeal: d.AfterMeal
                )).ToList(),
                IsPermanent: posology.IsPermanent,
               StartDate: posology.StartDate,
                EndDate: posology.EndDate
            );
        }

        public static ICollection<ValidationDto> ToValidationsDto(this IReadOnlyList<Validation> validations)
        {
            return validations.Select(v => v.ToValidationDto()).ToList();
        }

        public static ValidationDto ToValidationDto(this Validation validation)
        {
            return new ValidationDto(
                Id: validation.Id.Value,
                PharmacistId: validation.PharmacistId,
                PrescriptionId: validation.PrescriptionId.Value,
                PharmacistName: validation.PharmacistName,
                IsValid: validation.IsValid,
                Notes: validation.Notes,
                CreatedAt: validation.CreatedAt ?? DateTime.UtcNow
            );
        }
    }
}