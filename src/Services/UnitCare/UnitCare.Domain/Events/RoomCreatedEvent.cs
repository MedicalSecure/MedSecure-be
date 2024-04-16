using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Domain.Abstractions;
using UnitCare.Domain.Models;

namespace UnitCare.Domain.Events
{
    public record RoomCreatedEvent(Room room) : IDomainEvent;
}
