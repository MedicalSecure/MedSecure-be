

public class MedicationNotFoundException : NotFoundException
{
    public MedicationNotFoundException(Guid id) : base("Medication", id)
    {
    }
}
