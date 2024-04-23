
namespace Sensor.Domain.Models;

public class ThingSpeakDataResponse
{
    public Channel Channel { get; set; }
    public List<Feed> Feeds { get; set; }
}