using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.ValueObjects
{
     public record TestId
    {
        private TestId() { }

        public Guid Value { get; }

        private TestId(Guid value) => Value = value;

        public static TestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TestId cannot be empty!");
            }
            return new TestId(value);
        }
    }
}
