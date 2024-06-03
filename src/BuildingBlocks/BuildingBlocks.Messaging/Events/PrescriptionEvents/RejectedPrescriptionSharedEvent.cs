using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record RejectedPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PharmacistId { get; set; }
        public int Status { get; set; }
        public ICollection<SymptomSharedEvent> Symptoms { get; set; }
        public ICollection<DiagnosesSharedEvent> Diagnoses { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public UnitCarePlanSharedEvent UnitCare { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }
        public string PharmacistName { get; set; }
        public string Remarques { get; set; }

        // Empty constructor
        public RejectedPrescriptionSharedEvent() { }

        // Full constructor
        public RejectedPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            Guid pharmacistId,
            int status,
            ICollection<SymptomSharedEvent> symptoms,
            ICollection<DiagnosesSharedEvent> diagnoses,
            ICollection<PosologySharedEvent> posologies,
            UnitCarePlanSharedEvent unitCare,
            DietForPrescriptionSharedEvent diet,
            string pharmacistName,
            string remarques)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            PharmacistId = pharmacistId;
            Status = status;
            Symptoms = symptoms;
            Diagnoses = diagnoses;
            Posologies = posologies;
            UnitCare = unitCare;
            Diet = diet;
            PharmacistName = pharmacistName;
            Remarques = remarques;
        }
    }
}