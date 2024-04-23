

using BacPatient.Domain.Enums;

namespace BuildingBlocks.Messaging.Events;

public record BacPatientSharedEvent : IntegrationEvent
{
    public Guid BPModelId { get; init; } = default!;
    public Guid PatientId { get; init; } = default!;
    public Guid RoomId { get; init; } = default!;

    public Guid UnitCareId { get; init; } = default!;
    public int Bed { get; init; } = default!;

    public DateTime ServingDate { get; init; } = default!;
    public int Served { get; init; } = default!;
    public int ToServed { get; init; } = default!;
    public StatusBP Status { get; init; } = default!;

    public List<MedcinesShared> Meals { get; init; } = default!;
    
    
}

public record MedcinesShared
{
    public Guid MedId { get; init; } = default!;
    public string MedName { get; init; } = default!;
    public string MedForme { get; init; } = default!;
    public string MedDose { get; init; } = default!;
    public string MedUnit { get; init; } = default!;
    public DateTime MedDateExp{ get; init; } = default!;
    public int MedStock { get; init; } = default!;
    public List<string> MedNote { get; init; } = default!;

    public List<PosologyShared> Posologies { get; init; } = default!;
}

public record PosologyShared
{
    public Guid PosologyId { get; init; } = default!;
    public DateTime StartDate { get; init; } = default!;
    public DateTime EndDate { get; init; } = default!;
    public int QuantityBE { get; init; } = default!;

    public int QuanityAE { get; init; } = default!;
    public bool isPermanant { get; init; } = default!;

    public List<string> Hours { get; init; } = default!;


}
