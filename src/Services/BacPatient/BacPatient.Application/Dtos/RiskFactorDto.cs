using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Dtos
{


    public class RiskFactorDto
    {
        public List<RiskFactorDto> SubRiskFactor { get; set; } = new List<RiskFactorDto>();

        public RiskFactorDto? RiskFactorParent { get; set; }

        public Guid? RiskFactorParentId { get; set; }

        public Guid? RiskFactorId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsSelected { get; set; }

        public string Type { get; set; }

        public string Icon { get; set; }

    }
}
