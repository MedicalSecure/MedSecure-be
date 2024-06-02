using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Application.Extensions;

namespace Registration.Application.Patients.Queries.GetPatientByName;

public class GetPatientByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPatientByNameQuery, GetPatientByNameResult>
{
    public async Task<GetPatientByNameResult> Handle(GetPatientByNameQuery query, CancellationToken cancellationToken)
    {
        // get patients by Id using dbContext
        // return result
        var Registers = await dbContext.Registers
            .Where(r => r.Status == RegisterStatus.Archived)
            .ToListAsync();
        var patients = await dbContext.Patients
                 .AsNoTracking()
                 .Where(o => (o.FirstName + " " + o.LastName).Contains(query.name) ||
                     (o.LastName + " " + o.FirstName).Contains(query.name))
                 .OrderBy(o => o.DateOfBirth)
                 .ToListAsync(cancellationToken);

        var patientsDto = patients.Select(patient =>
        {
            if (Registers.Any(r => r.PatientId == patient.Id))
                return patient.ToPatientDto(archived: true);
            else
                return patient.ToPatientDto(archived: false);
        });

        return new GetPatientByNameResult(patientsDto);
    }
}