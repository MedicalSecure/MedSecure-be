using Prescription.Domain.ValueObjects;
using System.Reflection.Emit;

namespace Prescription.Domain.Entities
{
    public class Validation : Entity<ValidationId>
    {
        public Guid PharmacistId { get; private set; }
        public string? PharmacistName { get; private set; }
        public bool IsValid { get; private set; } = true;
        public string Notes { get; private set; }

        public PrescriptionId PrescriptionId { get; private set; }

        //nav properties
        public Prescription? Prescription { get; set; }

        private Validation()
        { } // Required for EF Core

        public static Validation CreateValidated(PrescriptionId prescriptionId, Guid pharmacistId, string? notes, string? pharmacistName)
        {
            // when validating, we can add no notes
            return new Validation()
            {
                CreatedAt = DateTime.Now,
                Id = ValidationId.Of(Guid.NewGuid()),
                PharmacistName = pharmacistName,
                Notes = notes ?? "No Notes were given",
                PharmacistId = pharmacistId,
                IsValid = true,
                PrescriptionId = prescriptionId,
            };
        }

        public static Validation CreateRejected(PrescriptionId prescriptionId, Guid pharmacistId, string notes, string? pharmacistName)
        {
            // when rejected, we must give notes
            return new Validation()
            {
                CreatedAt = DateTime.Now,
                Id = ValidationId.Of(Guid.NewGuid()),
                PharmacistName = pharmacistName,
                Notes = notes,
                PharmacistId = pharmacistId,
                IsValid = false,
                PrescriptionId = prescriptionId,
            };
        }
    }
}