using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Dtos
{
    public class TestDto
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public Language Language { get; set; }

        public TestType Type { get; set; }

        public Guid RegisterId { get; set; }
    }

}
