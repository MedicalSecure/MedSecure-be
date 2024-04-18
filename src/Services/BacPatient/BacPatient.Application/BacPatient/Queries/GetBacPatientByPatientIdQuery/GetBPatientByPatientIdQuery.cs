﻿namespace BacPatient.Application.BacPatient.Queries.GetBacPatientByPatientIdQuery
{
    public record GetBPatientByPatientIdQuery(Guid id) : IQuery<GetBPByPatientIdResult>;

    public record GetBPByPatientIdResult(IEnumerable<BacPatientDto> BacPatients);

}

