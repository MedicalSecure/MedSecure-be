

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

            var registers = await dbContext.Registers
                           .Include(t=>t.Allergy).ThenInclude(k => k.SubRiskFactors)
                           .Include(t=>t.FamilyMedicalHistory).ThenInclude(k=>k.SubRiskFactors)
                           .Include(t=>t.PersonalMedicalHistory).ThenInclude(k => k.SubRiskFactors)
                           .Include(t=>t.Disease).ThenInclude(k => k.SubRiskFactors)
                           .Include(t=>t.Tests)
                           .Include(t=>t.History)
                           .OrderBy(o => o.Patient.Id)
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
