using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Visit.Application.Patients.Queries.GetPatientById;

public class GetPatientByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetPatientByIdQuery,GetPatientByIdResult>
{

    public async Task<GetPatientByIdResult> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
    {
        //get visits by id doctor

        var patients = await dbContext.Patients
            .AsNoTracking()
             .Where(patient => patient.Id == PatientId.Of(query.id))
             .OrderBy(patient => patient.Id)
             .ToListAsync(cancellationToken);
        return new GetPatientByIdResult(patients.ToPatientDto());
    }
}