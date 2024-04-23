using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Application.Dtos;

//public record ThingspeakDto(Guid id, Channel Channel, List<Feed> Feeds);
public record ThingspeakDto(Guid Id, Channel Channel, List<Feed> Feeds);

public record Channel(int Id, string Name, string Description, string Latitude, string Longitude, string Field1, string Field2, string Field3, string Field4, DateTime CreatedAt, DateTime UpdatedAt, int LastEntryId);

public record Feed(DateTime CreatedAt, int EntryId, string Field1, string Field2, string Field3, string Field4);

