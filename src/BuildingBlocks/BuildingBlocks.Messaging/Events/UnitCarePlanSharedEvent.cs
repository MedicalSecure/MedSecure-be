﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events;


public record UnitCarePlanSharedEvent : IntegrationEvent
{
    public Guid UnitCarePlanId { get; init; } = default!;
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Type { get; private set; } = default!;

    public string UnitStatus { get; private set; } = default!;
    public List<RoomShared> Rooms { get; init; } = default!;

    public List<PersonnelShared> Personnels { get; init; } = default!;


}


public record PersonnelShared
{
    public Guid PersonnelId { get; init; } = default!;
    public string Name { get; set; } = default!;
    public string Shift { get; set; } = default!;

    public string Gender { get; set; } = default!;
}

public record RoomShared
{
    public Guid RoomId { get; init; } = default!;

    public decimal RoomNumber { get; set; } = default!;
    public string Status { get; set; } = default!;
   
    public List<EquipmentShared> Equipments { get; init; } = default!;
}


public record EquipmentShared
{
    public Guid EquipmentId { get; init; } = default!;
    public string Name { get; set; } = default!;

    public string Reference { get; set; } = default!;
    public string EqStatus { get; set; } = default!;

    public string EqType { get; set; } = default!;
}