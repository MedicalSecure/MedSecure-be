using Prescription.Domain.Entities;

namespace Prescription.Application.Extensions
{
    public static class PrescriptionExtension
    {
        public static IEnumerable<PrescriptionDto> ToPrescriptionsDto(this IEnumerable<Domain.Entities.Prescription> prescriptions, bool includeRegister = true)
        {
            return prescriptions.Select(p => p.ToPrescriptionDto(includeRegister));
        }

        public static PrescriptionDto ToPrescriptionDto(this Domain.Entities.Prescription pres, bool includeRegister = false)
        {
            if (includeRegister)
            {
                var x = new PrescriptionDto(
                    Id: pres.Id.Value,
                    RegisterId: pres.RegisterId.Value,
                    DoctorId: pres.DoctorId.Value,
                    Symptoms: pres.Symptoms.ToSymptomsDto(),
                    Diagnoses: pres.Diagnosis.ToDiagnosisDto(),
                    Posologies: pres.Posology.ToPosologiesDto(),
                    CreatedAt: pres.CreatedAt ?? DateTime.UtcNow,
                    UnitCareId: pres.UnitCareId?.Value,
                    DietId: pres.DietId?.Value,
                    LastModified: pres.LastModified,
                    CreatedBy: pres.CreatedBy,
                    LastModifiedBy: pres.LastModifiedBy
                );
                return x;
            }
            else
            {
                var x = new PrescriptionDto(
                    Id: pres.Id.Value,
                    RegisterId: pres.RegisterId.Value,
                    DoctorId: pres.DoctorId.Value,
                    Symptoms: pres.Symptoms.ToSymptomsDto(),
                    Diagnoses: pres.Diagnosis.ToDiagnosisDto(),
                    Posologies: pres.Posology.ToPosologiesDto(),
                    CreatedAt: pres.CreatedAt ?? DateTime.UtcNow,
                    UnitCareId: pres.UnitCareId?.Value,
                    DietId: pres.DietId?.Value,
                    LastModified: pres.LastModified,
                    CreatedBy: pres.CreatedBy,
                    LastModifiedBy: pres.LastModifiedBy
                );
                return x;
            }
        }

        public static IEnumerable<DispensesDto> ToDispensesDto(this IEnumerable<Dispense> dispenses)
        {
            return dispenses.Select(d => d.ToDispenseDto());
        }

        public static DispensesDto ToDispenseDto(this Dispense dispense)
        {
            return new DispensesDto(
                Id: dispense.Id.Value,
                PosologyId: dispense.PosologyId.Value,
                Hour: dispense.Hour,
                BeforeMeal: dispense.BeforeMeal,
                AfterMeal: dispense.AfterMeal
            );
        }

        public static ICollection<PosologyDto> ToPosologiesDto(this IReadOnlyList<Posology> posologies)
        {
            return posologies.Select(posology => posology.ToPosologyDto()).ToList();
        }

        public static PosologyDto ToPosologyDto(this Posology posology)
        {
            return new PosologyDto(
                 Id: posology.Id.Value,
                PrescriptionId: posology.PrescriptionId.Value,
                Medication: posology.Medication?.ToMedicationDto(),
                MedicationId: posology.MedicationId.Value,
                Comments: posology.Comments.Select(c => new CommentsDto(
                    Id: c.Id.Value,
                    PosologyId: posology.Id.Value,
                    Label: c.Label,
                    Content: c.Content
                )).ToList(),
               Dispenses: posology.Dispenses.Select(d => new DispensesDto(
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
    }
}