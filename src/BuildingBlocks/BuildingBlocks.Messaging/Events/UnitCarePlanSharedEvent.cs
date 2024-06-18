using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events;

public record UnitCarePlanSharedEvent : IntegrationEvent
{
    public Guid Id { get; init; } = default!;
    public string Title { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Type { get; private set; } = default!;

    public int UnitStatus { get; private set; } = default!;
    public List<RoomShared> Rooms { get; init; } = default!;

    public List<PersonnelShared> Personnels { get; init; } = default!;
}

public record PersonnelShared
{
    public Guid Id { get; init; } = default!;
    public string Name { get; set; } = default!;
    public int Shift { get; set; } = default!;

    public int Gender { get; set; } = default!;
}

public record RoomShared
{
    public Guid Id { get; init; } = default!;

    public int RoomNumber { get; set; } = default!;
    public int Status { get; set; } = default!;

    public List<EquipmentShared> Equipments { get; init; } = default!;
}

public record EquipmentShared
{
    public Guid Id { get; init; } = default!;
    public string Name { get; set; } = default!;

    public string Reference { get; set; } = default!;
    public int EqStatus { get; set; } = default!;

    public int EqType { get; set; } = default!;
}