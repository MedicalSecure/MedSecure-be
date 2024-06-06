using Medication.Domain.Enums;

namespace Medication.Domain.Models;

public class Validation : Entity<ValidationId>
{
    private readonly List<Posology> _posologies = new();
    public Guid PrescriptionId { get; init; }
    public Guid? PharmacistId { get; private set; }
    public string? PharmacistName { get; private set; }
    public ValidationStatus Status { get; private set; }
    public string? Notes { get; private set; }
    public string UnitCareJson { get; private set; }
    public IReadOnlyCollection<Posology> Posologies => _posologies.AsReadOnly();

    public Validation()
    {
    } // For EF and Mapster

    private Validation(Guid prescriptionId, string unitCareJson)
    {
        Id = ValidationId.Of(Guid.NewGuid());
        PrescriptionId = prescriptionId;
        PharmacistId = null;
        PharmacistName = null;
        Status = ValidationStatus.Pending;
        Notes = null;
        CreatedAt = DateTime.UtcNow;
        this.UnitCareJson = unitCareJson;
    }

    public void addPosology(Posology posology)
    {
        _posologies.Add(posology);
    }

    public static Validation Create(Guid prescriptionId, string unitCare)
    {
        return new Validation(prescriptionId, unitCare);
    }

    public void Validate(Guid pharmacistId, string notes = "No notes", string? pharmacistName = null)
    {
        PharmacistId = pharmacistId;
        Notes = notes;
        PharmacistName = pharmacistName;
        Status = ValidationStatus.Validated;
    }

    public void Reject(Guid pharmacistId, string notes, string? pharmacistName = null)
    {
        PharmacistId = pharmacistId;
        Notes = notes;
        PharmacistName = pharmacistName;
        Status = ValidationStatus.Rejected;
    }
}