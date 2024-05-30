using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prescription.Domain.Entities.UnitCareRoot;

namespace Prescription.Domain.Events.UnitCareEvents
{
    public record PersonnelCreatedEvent(Personnel personnel) : IDomainEvent;
}