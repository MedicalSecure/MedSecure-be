
namespace Visit.Application.Patients.Queries.GetPatientByNameQuery;
public record GetPatientByNameQuery(string name) : IQuery<GetPatientByNameResult>;

public record GetPatientByNameResult(IEnumerable<PatientDto> Patients);

