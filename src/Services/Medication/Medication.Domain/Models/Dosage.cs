namespace Medication.Domain.Models;


public class Dosage : Aggregate<DosageId>
{
    public string? Code { get; private set; }
    public string? Label { get; private set; }

    public static Dosage Create(
        DosageId id,
        string code,
        string label
    )
    {
        var dosage = new Dosage()
        {
            Id = id,
            Code = code,
            Label = label
        };

        dosage.AddDomainEvent(new DosageCreatedEvent(dosage));
        return dosage;
    }

    public void Update(string code, string label)
    {
        Code = code;
        Label = label;

        AddDomainEvent(new DosageUpdatedEvent(this));
    }

}
