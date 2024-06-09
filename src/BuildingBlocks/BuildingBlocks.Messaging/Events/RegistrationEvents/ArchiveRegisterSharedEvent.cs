using BuildingBlocks.Messaging.Events.RegistrationSharedEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.RegistrationEvents
{
    public record ArchiveRegisterSharedEvent(Guid id) : IntegrationEvent;
}