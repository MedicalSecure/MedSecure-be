﻿

using BacPatient.Domain.Models.RegisterRoot;

namespace BacPatient.Application.Extensions
{
    public static class PrescriptionExtension
    {
        public static IEnumerable<PrescriptionDto> ToPrescriptionsDto(this IEnumerable<Prescription> prescriptions)
        {
            return prescriptions.Select(p => p.ToPrescriptionDto());
        }
      /*  public static IEnumerable<Prescription> ToPrescriptionsEntities(this IEnumerable<PrescriptionDto> prescriptions)
        {
            return prescriptions.Select(p => p.ToPrescription());
        }
  */
        public static PrescriptionDto ToPrescriptionDto(this Prescription pres)
        {
            var x = new PrescriptionDto(
                Id: pres.Id,
                RegisterId: pres.RegisterId,
                Symptoms: pres.Symptoms.ToSymptomsDto(),
                Diagnoses: pres.Diagnosis.ToDiagnosisDto(),
                DoctorId: pres.DoctorId,
                Posologies: pres.Posology.ToPosologiesDto(),
                CreatedAt: pres.CreatedAt,
                LastModified: pres.LastModified,
                CreatedBy: pres.CreatedBy,
                LastModifiedBy: pres.LastModifiedBy
            );
            return x;
        }
   


        public static IEnumerable<DispensesDto> ToDispensesDto(this IEnumerable<Dispense> dispenses)
        {
            return dispenses.Select(d => d.ToDispenseDto());
        }

        public static DispensesDto ToDispenseDto(this Dispense dispense)
        {
            return new DispensesDto(
                Id: dispense.Id,
                PosologyId: dispense.PosologyId,
                Hour: dispense.Hour,
                QuantityBE: dispense.QuantityBE,
                QuantityAE: dispense.QuantityAE
            );
        }

        public static ICollection<PosologyDto> ToPosologiesDto(this IReadOnlyList<Posology> posologies)
        {
            return posologies.Select(posology => posology.ToPosologyDto()).ToList();
        }

        public static PosologyDto ToPosologyDto(this Posology posology)
        {
            return new PosologyDto(
                Id: posology.Id,
                PrescriptionId: posology.PrescriptionId,
                Medication: posology.Medication.ToMedicationDto(),
                Comments: posology.Comments.Select(c => new CommentsDto(
                    Id: c.Id,
                    PosologyId: posology.Id,
                    Label: c.Label,
                    Content: c.Content
                )).ToList(),
                Dispenses: posology.Dispenses.Select(d => new DispensesDto(
                    Id: d.Id,
                    PosologyId: posology.Id,
                    Hour: d.Hour,
                    QuantityBE: d.QuantityBE,
                    QuantityAE: d.QuantityAE
                )).ToList(),
                IsPermanent: posology.IsPermanent,
                StartDate: posology.StartDate,
                EndDate: posology.EndDate
            );
        }
    }
}