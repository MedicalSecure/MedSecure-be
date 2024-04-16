using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Domain.Exceptions;

namespace UnitCare.Domain.ValueObjects
{
    public record UnitCareId
    {
        public Guid Value { get; }

        private UnitCareId(Guid value) => Value = value;

        public static UnitCareId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UnitCareId cannot be empty!");
            }
            return new UnitCareId(value);
        }
    }
}
