using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record PoslogyId
    {
        public Guid Value { get; }
        private PoslogyId() { }
        private PoslogyId(Guid value) => Value = value;

        public static PoslogyId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PoslogyId cannot be empty!");
            }
            return new PoslogyId(value);
        }
    }
}
