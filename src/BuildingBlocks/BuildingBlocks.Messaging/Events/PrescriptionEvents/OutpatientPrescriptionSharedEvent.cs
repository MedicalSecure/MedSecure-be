using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record OutpatientPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public int Status { get; set; }
        public ICollection<SymptomSharedEvent> Symptoms { get; set; }
        public ICollection<DiagnosesSharedEvent> Diagnoses { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }
        public DateTime CreatedAt { get; set; }

        // Empty constructor
        public OutpatientPrescriptionSharedEvent()
        { }

        // Full constructor
        public OutpatientPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            int status,
            ICollection<SymptomSharedEvent> symptoms,
            ICollection<DiagnosesSharedEvent> diagnoses,
            ICollection<PosologySharedEvent> posologies,
            DietForPrescriptionSharedEvent diet,
            DateTime createdAt)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            Status = status;
            Symptoms = symptoms;
            Diagnoses = diagnoses;
            Posologies = posologies;
            Diet = diet;
            CreatedAt = createdAt;
        }
    }
}