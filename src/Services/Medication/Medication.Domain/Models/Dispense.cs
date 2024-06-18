namespace Medication.Domain.Models;

public class Dispense : Entity<DispenseId>
{
    public int Hour { get; private set; }

    public int? BeforeMeal { get; private set; }
    public int? AfterMeal { get; private set; }
    public PosologyId? PosologyId { get; private set; } = default!;
    public Posology? Posology { get; private set; }

    private Dispense()
    { } // Required for EF Core

    private Dispense(DispenseId id, PosologyId posologyId, int hour, int? QuantityBM, int? QuantityAM, string createdBy, DateTime createdAt)
    {
        if (QuantityBM == null && QuantityAM == null)
            throw new ArgumentException("At least one of QuantityBM or QuantityAM must be provided.");

        if (QuantityBM == null || QuantityBM == 0)
        {
            if (QuantityAM.HasValue && QuantityAM > 0) AfterMeal = QuantityAM ?? 0;
            else throw new ArgumentException("At least one of QuantityBM or QuantityAM must be provided.");
        }
        else if (QuantityAM == null || QuantityAM == 0)
        {
            if (QuantityBM.HasValue && QuantityBM > 0) BeforeMeal = QuantityBM ?? 0;
            else throw new ArgumentException("At least one of QuantityBM or QuantityAM must be provided.");
        }
        else
        {
            BeforeMeal = QuantityBM ?? 0;
            AfterMeal = QuantityAM ?? 0;
        }
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        Id = id;
        PosologyId = posologyId;
        Hour = hour;
    }

    public static Dispense Create(PosologyId posologyId, int hour, int? QuantityBM, int? QuantityAM, string createdBy, DateTime createdAt = default)
    {
        var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

        return new Dispense(DispenseId.Of(Guid.NewGuid()), posologyId, hour, QuantityBM, QuantityAM, createdBy, CreatedAt);
    }

    public static Dispense Create(DispenseId Id, PosologyId posologyId, int hour, int? QuantityBM, int? QuantityAM, string createdBy, DateTime createdAt = default)
    {
        var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

        return new Dispense(Id, posologyId, hour, QuantityBM, QuantityAM, createdBy, CreatedAt);
    }
}