
namespace Visit.Domain.Models;

public class VisitPatient
{
    public VisitId VisitId { get; set; }
    public Visit Visit { get; set; }

    public PatientId PatientId { get; set; }
    public Patient Patient { get; set; }
}
