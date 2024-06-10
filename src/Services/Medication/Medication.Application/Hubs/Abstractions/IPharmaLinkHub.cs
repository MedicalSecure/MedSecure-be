using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Hubs.Abstractions
{
    public interface IPharmaLinkHub
    {
        public Task SendEventToAll(InpatientPrescriptionSharedEvent p);
    }
}