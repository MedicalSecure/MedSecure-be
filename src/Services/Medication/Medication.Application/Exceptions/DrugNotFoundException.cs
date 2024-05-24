namespace Medication.Application.Exceptions;


public class DrugNotFoundException : NotFoundException
{
    public DrugNotFoundException(Guid id) : base("Drug", id)
    {
    }
}


