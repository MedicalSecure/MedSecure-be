
public class PatientNotFoundException : NotFoundException
{
    public PatientNotFoundException(Guid id) : base("Patient", id)
    {
    }
}

