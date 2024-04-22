
namespace BacPatient.Application.BacPatient.Queries.GetBacPatientById
{
    
    public record GetBacPatientByIdQuery(Guid Id) : IQuery<GetBacPatientByIdResult>;

    public record GetBacPatientByIdResult(IEnumerable<BacPatientDto> BacPatients);
}
