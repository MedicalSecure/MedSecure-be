using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Registration.Application.Dtos;


namespace Registration.Application.Patients.Queries.GetPatients
{
    public record GetPatientsQuery(PaginationRequest PaginationRequest) : IQuery<GetPatientsResult>;
    public record GetPatientsResult(PaginatedResult<PatientDto> Patients);

}
