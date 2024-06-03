using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record ValidPrescriptionSharedEvent(
        Guid Id,
        Guid RegisterId,
        Guid DoctorId,
        Guid PharmacistId,
        int Status,
        ICollection<SymptomSharedEvent> Symptoms,
        ICollection<DiagnosesSharedEvent> Diagnoses,
        ICollection<PosologySharedEvent> Posologies,
        UnitCarePlanSharedEvent UnitCare,
        DietForPrescriptionSharedEvent Diet,
        string PharmacistName,
        string Remarques
        ) : IntegrationEvent;
}