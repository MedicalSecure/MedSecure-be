
using BacPatient.Application.BacPatient.Queries.GetBacPatient;

namespace BacPatient.Application.BacPatient.Queries.GetBPHandler;

public class GetBacPatientHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetBacPatientQuery, GetBacPatientResult>
{
    public async Task<GetBacPatientResult> Handle(GetBacPatientQuery query, CancellationToken cancellationToken)
    { var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var totalCount = await dbContext.BacPatients.LongCountAsync(cancellationToken);
        var med = await dbContext.Medications.ToArrayAsync(cancellationToken);
        var comment = await dbContext.Comments.ToArrayAsync(cancellationToken);
        var dispense = await dbContext.Dispenses.ToArrayAsync(cancellationToken);
        var unitcare = await dbContext.UnitCares.ToArrayAsync(cancellationToken);

        var room = await dbContext.Rooms.ToArrayAsync(cancellationToken);
        var equipment = await dbContext.Equipments.ToArrayAsync(cancellationToken);
        var bacPatients = await dbContext.BacPatients
             .Include(bp => bp.Prescription)
             .Include(bp => bp.Prescription.Register)
             .Include(bp => bp.Prescription.Register.Patient)
             .Include(bp => bp.Prescription.Posology)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetBacPatientResult(
            new PaginatedResult<BacPatientDto>(
                pageIndex,
                pageSize,
                totalCount,
                bacPatients.ToBacPatientDtos()));
    }
}