using RiskFactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RiskFactor
{
public class Register
{

    public List<RiskFactor> familymedicalhistory { get; set; }
    public List<RiskFactor> personalMedicalHistory { get; set; }

}
    public class RiskFactor
    {
        public string key { get; set; }
        public string value { get; set; }
        public List<RiskFactor> subRiskfactory { get; set; }
    }
}
