using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Models;

public class ThingSpeakDataResponse
{
    public Channel Channel { get; set; }
    public List<Feed> Feeds { get; set; }
}

public class Channel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int LastEntryId { get; set; }
}

public class Feed
{
    public DateTime CreatedAt { get; set; }
    public int EntryId { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
}
