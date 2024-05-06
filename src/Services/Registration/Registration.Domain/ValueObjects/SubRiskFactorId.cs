using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.ValueObjects
{
    public class SubRiskFactorId
    {
        public Guid Value { get; }

        private SubRiskFactorId(Guid value) => Value = value;

        public static SubRiskFactorId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RiskFactorId cannot be empty!");
            }
            return new SubRiskFactorId(value);
        }
    }
}


