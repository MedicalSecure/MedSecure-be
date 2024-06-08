using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Domain.Enums
{
    public enum ValidationStatus
    {
        Pending = 0,
        Validated = 1,
        Rejected = 2,
        Cancelled = 3
    }
}