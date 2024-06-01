using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record DispenseId
    {
        private DispenseId() { }

        public Guid Value { get; }

        private DispenseId(Guid value) => Value = value;

        public static DispenseId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("DispenseId cannot be empty!");
            }
            return new DispenseId(value);
        }
    }
}
