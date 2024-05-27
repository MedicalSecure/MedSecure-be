namespace BacPatient.Application.BacPatient.Queries.GetBacPatient;
    
public record GetBacPatientQuery(PaginationRequest PaginationRequest)
: IQuery<GetBacPatientResult>;

public record GetBacPatientResult(PaginatedResult<BacPatientDto> BacPatients);