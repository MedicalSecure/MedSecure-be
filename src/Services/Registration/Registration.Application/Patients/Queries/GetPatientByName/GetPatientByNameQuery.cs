using BuildingBlocks.CQRS;
using Registration.Application.Dtos;


namespace Registration.Application.Patients.Queries.GetPatientByName
{
    public record GetPatientByNameQuery(string name):IQuery<GetPatientByNameResult>;
    
    public record GetPatientByNameResult(IEnumerable<PatientDto> Patients);
}
