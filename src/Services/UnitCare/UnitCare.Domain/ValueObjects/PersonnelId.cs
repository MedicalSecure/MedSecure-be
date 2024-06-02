using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Domain.ValueObjects
{
    public record PersonnelId
    {
        public Guid Value { get; }

        private PersonnelId(Guid value) => Value = value;

        public static PersonnelId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException(" PersonnelId cannot be empty!");
            }
            return new PersonnelId(value);
        }
    }
}
