using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
   
    public record PosologyId
    {
        private PosologyId() { }

        public Guid Value { get; }

        private PosologyId(Guid value) => Value = value;

        public static PosologyId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("PosologyId cannot be empty!");
            }
            return new PosologyId(value);
        }
    }
}
