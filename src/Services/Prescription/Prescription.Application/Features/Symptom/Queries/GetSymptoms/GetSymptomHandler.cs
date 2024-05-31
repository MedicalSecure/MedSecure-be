using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prescription.Application.Features.Symptom.Queries.GetSymptom
{
    public class GetSymptomHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSymptomQuery, GetSymptomResult>
    {
        public async Task<GetSymptomResult> Handle(GetSymptomQuery query, CancellationToken cancellationToken)
        {
            // get Symptom with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Symptoms.LongCountAsync(cancellationToken);

            var Symptom = await dbContext.Symptoms
                           .OrderBy(o => o.Name)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetSymptomResult(
                new PaginatedResult<SymptomDTO>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    Symptom.ToSymptomsDto()));
        }
    }
}