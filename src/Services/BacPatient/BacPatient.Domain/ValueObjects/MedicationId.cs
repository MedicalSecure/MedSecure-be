using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record MedicationId
    {
        private MedicationId() { }

        public Guid Value { get; }

        private MedicationId(Guid value) => Value = value;

        public static MedicationId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("MedicationId cannot be empty!");
            }
            return new MedicationId(value);
        }
    }
}
