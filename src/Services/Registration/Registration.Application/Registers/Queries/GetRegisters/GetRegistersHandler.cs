

namespace Registration.Application.Registers.Queries.GetRegisters
{
    public class GetRegistersHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetRegistersQuery, GetRegistersResult>
    {
        public async Task<GetRegistersResult> Handle(GetRegistersQuery query, CancellationToken cancellationToken)

        {
            // get patients with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Registers.LongCountAsync(cancellationToken);

            //Auto include the riskFactors
            var riskFactor = await dbContext.RiskFactors.ToListAsync(cancellationToken);

            var registers = await dbContext.Registers
                            .Include(t =>t.Patient)
                            .Include(t=>t.Tests)
                            .Include(r => r.FamilyMedicalHistory)
                            .Include(r => r.PersonalMedicalHistory)
                            .Include(r => r.Disease)
                            .Include(r => r.Allergy)
                            .Include(t=>t.History)
                            .OrderByDescending(o => o.CreatedAt)
                            .Skip(pageSize * pageIndex)
                            .Take(pageSize)
                            .ToListAsync(cancellationToken);

            return new GetRegistersResult(
                new PaginatedResult<RegisterDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    registers.ToRegisterDto()));
        }
    }
}
