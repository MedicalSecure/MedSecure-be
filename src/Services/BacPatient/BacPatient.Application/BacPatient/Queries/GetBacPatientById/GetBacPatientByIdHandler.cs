
namespace BacPatient.Application.BacPatient.Queries.GetBacPatientById
{


    public class GetBacPatientByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetBacPatientByIdQuery, GetBacPatientByIdResult>
    {
        public async Task<GetBacPatientByIdResult> Handle(GetBacPatientByIdQuery query, CancellationToken cancellationToken)
        {
            var bacPatients = await dbContext.BacPatients
            .Where(o => o.Id == BacPatienId.Of(query.Id))
             .Include(o => o.Medicines)
             .AsNoTracking()
                 .ToListAsync(cancellationToken);

            return new GetBacPatientByIdResult(bacPatients.ToBacPatientDtos());
        }
    }
}