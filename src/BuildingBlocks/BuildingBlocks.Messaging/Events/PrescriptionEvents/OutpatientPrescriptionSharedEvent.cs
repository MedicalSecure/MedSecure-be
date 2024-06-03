using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record outpatientPrescriptionSharedEvent(
    Guid Id,
    Guid RegisterId,
    Guid DoctorId,
    int Status,
    ICollection<SymptomSharedEvent> Symptoms,
    ICollection<DiagnosesSharedEvent> Diagnoses,
    ICollection<PosologySharedEvent> Posologies,
    DietForPrescriptionSharedEvent Diet
    ) : IntegrationEvent;
}