namespace BacPatient.Application.BacPatient.Queries.GetBacPatientByPatientId;

public record GetBPatientByPatientIdQuery(Guid id) : IQuery<GetBPByPatientIdResult>;

public record GetBPByPatientIdResult(IEnumerable<BacPatientDto> BacPatients);

