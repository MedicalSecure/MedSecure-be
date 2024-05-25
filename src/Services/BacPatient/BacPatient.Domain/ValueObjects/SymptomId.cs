using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record SymptomId
    {
        private SymptomId() { }

        public Guid Value { get; }

        private SymptomId(Guid value) => Value = value;

        public static SymptomId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("SymptomId cannot be empty!");
            }
            return new SymptomId(value);
        }
    }
}
