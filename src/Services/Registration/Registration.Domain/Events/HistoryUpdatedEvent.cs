using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Events
{
    public record HistoryUpdatedEvent(History history) : IDomainEvent
    {
    }
}
