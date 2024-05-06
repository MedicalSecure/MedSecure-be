using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Dtos
{
    public class HistoryDto
    {
        public DateTime Date { get; set; }

        public Status Status { get; set; }

        public Guid RegisterId { get; set; }
    }

}
