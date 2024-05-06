using Registration.Application.Registers.Queries.GetRegisters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Histories.Queries.GetHistories
{
    internal class GetHistoriesHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetHistoriesQuery, GetHistoriesResult>
    {
        public async Task<GetHistoriesResult> Handle(GetHistoriesQuery query, CancellationToken cancellationToken)

        {
            // get patients with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Registers.LongCountAsync(cancellationToken);

            var histories = await dbContext.Histories
                           .OrderBy(o => o.RegisterId)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetHistoriesResult(
                new PaginatedResult<HistoryDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    histories.ToHistoryDto()));
        }
    }
}

