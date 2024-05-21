using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.ValueObjects
{
   
    public record DailyMealId
    {
        public Guid Value { get; }

        private DailyMealId(Guid value) => Value = value;

        public static DailyMealId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("DailyMealId cannot be empty!");
            }
            return new DailyMealId(value);
        }
    }
}
