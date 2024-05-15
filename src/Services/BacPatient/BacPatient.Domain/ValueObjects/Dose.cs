using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Domain.ValueObjects
{
    public record Dose(string Quantity, bool isValid = false, bool isPostValid = false);

}
