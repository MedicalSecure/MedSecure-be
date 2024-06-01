
namespace Visit.Application.Patients.Queries.GetPatients;

public record GetPatientsQuery(PaginationRequest PaginationRequest)
: IQuery<GetPatientsResult>;

public record GetPatientsResult(PaginatedResult<PatientDto> Patients);