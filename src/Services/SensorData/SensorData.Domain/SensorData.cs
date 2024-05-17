using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorData.Domain
{
    public class SensorData
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Electricity { get; set; }
        public double Luminosity { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
