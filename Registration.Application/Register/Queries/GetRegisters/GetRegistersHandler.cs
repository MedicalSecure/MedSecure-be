
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Application.Extensions;

namespace Registration.Application.Register.Queries.GetRegisters
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
                           .OrderBy(o => o.PersonalMedicalHistory)
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
