using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record ValidatedPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PharmacistId { get; set; }
        public Guid BedId { get; set; }
        public int Status { get; set; }
        public ICollection<SymptomSharedEvent> Symptoms { get; set; }
        public ICollection<DiagnosesSharedEvent> Diagnoses { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public UnitCarePlanSharedEvent UnitCare { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }
        public string PharmacistName { get; set; }
        public string Remarques { get; set; }

        public DateTime CreatedAt { get; set; }

        // Empty constructor
        public ValidatedPrescriptionSharedEvent() { }

        // Full constructor
        public ValidatedPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            Guid pharmacistId,
            Guid bedId,
            int status,
            ICollection<SymptomSharedEvent> symptoms,
            ICollection<DiagnosesSharedEvent> diagnoses,
            ICollection<PosologySharedEvent> posologies,
            UnitCarePlanSharedEvent unitCare,
            DietForPrescriptionSharedEvent diet,
            string pharmacistName,
            string remarques,
            DateTime createdAt)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            PharmacistId = pharmacistId;
            BedId = bedId;
            Status = status;
            Symptoms = symptoms;
            Diagnoses = diagnoses;
            Posologies = posologies;
            UnitCare = unitCare;
            Diet = diet;
            PharmacistName = pharmacistName;
            Remarques = remarques;
            CreatedAt = createdAt;
        }
    }
}