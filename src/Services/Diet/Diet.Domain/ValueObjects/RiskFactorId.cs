using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.ValueObjects
{
   
    public record RiskFactorId
    {
        private RiskFactorId() { }

        public Guid Value { get; }

        private RiskFactorId(Guid value) => Value = value;

        public static RiskFactorId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RiskFactorId cannot be empty!");
            }
            return new RiskFactorId(value);
        }
    }
}
