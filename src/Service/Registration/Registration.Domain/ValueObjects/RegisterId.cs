
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.ValueObjects
{
    public record RegisterId
    {
        public Guid Value { get; }

        private RegisterId(Guid value) => Value = value;

        public static RegisterId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RegisterId cannot be empty!");
            }
            return new RegisterId(value);
        }
    }
}
