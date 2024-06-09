using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.Drugs
{
    public record PrescriptionValidationSharedEvent : IntegrationEvent
    {
        public Guid PrescriptionId { get; set; }
        public Guid PharmacistId { get; set; }
        public string PharmacistName { get; set; }
        public string? Notes { get; set; }
        public bool Validated { get; set; } = false;

        public string UnitCareJson { get; set; }

        public PrescriptionValidationSharedEvent()
        {
        }

        public PrescriptionValidationSharedEvent(Guid presId, Guid pharmacistId, string pharmacistName, string unitCareJson, bool validated = true, string? notes = null)
        {
            PrescriptionId = presId;
            PharmacistId = pharmacistId;
            PharmacistName = pharmacistName;
            UnitCareJson = unitCareJson;
            Validated = validated;
            Notes = notes;
        }
    }
}