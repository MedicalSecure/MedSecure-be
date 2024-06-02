using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record DiagnosisDeletedSharedEvent
    {
        public string props { get; init; } = default!;
    }
}