using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Models;
public  class SearchCriteria
{
    public string Keyword { get; set; }
    public SensorType sensorType { get; set; }
    public Location location { get; set; }
    
    // Implementing TryParse method
    public static bool TryParse(string input, out SearchCriteria result)
    {
        result = null;

        // Logic to parse the input string and populate the SearchCriteria object
        // Example: Split the input string and assign values to SearchCriteria properties
        // Ensure to handle parsing errors gracefully

        // For demonstration, let's just return true and create a dummy object
        result = new SearchCriteria();
        return true;
    }
}
