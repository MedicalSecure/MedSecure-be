using BuildingBlocks.Exceptions;

namespace Medication.Application.Exceptions;

public class DosageNotFoundException : NotFoundException
{
    public DosageNotFoundException(Guid id) : base("Dosage", id)
    {
    }
}
