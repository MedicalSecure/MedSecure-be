using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.ValueObjects
{
    public record DiagnosisId
    {
        private DiagnosisId() { }

        public Guid Value { get; }

        private DiagnosisId(Guid value) => Value = value;

        public static DiagnosisId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException(" DiagnosisId cannot be empty!");
            }
            return new DiagnosisId(value);
        }
    }

}
