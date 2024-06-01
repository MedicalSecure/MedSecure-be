using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Patients.Queries.GetPatientById;

public record GetPatientByIdQuery(Guid id) : IQuery<GetPatientByIdResult>;
public record GetPatientByIdResult(IEnumerable<PatientDto> Patients);