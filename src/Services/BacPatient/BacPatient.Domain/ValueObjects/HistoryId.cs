using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record HistoryId
    {
        private HistoryId() { }

        public Guid Value { get; }

        private HistoryId(Guid value) => Value = value;

        public static HistoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("HistoryId cannot be empty!");
            }
            return new HistoryId(value);
        }
    }
}
