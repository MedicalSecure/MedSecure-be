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
    public class GetSymptomByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetSymptomByIdQuery, GetSymptomResult>
    {
        public async Task<GetSymptomResult> Handle(GetSymptomByIdQuery query, CancellationToken cancellationToken)
        {
            // get Symptom with singke page
            // return result

            var Symptom = await dbContext.Symptoms.FindAsync(query.Id);

            var totalCount = Symptom == null ? 0 : 1;

            List<SymptomDTO> returnList = [];
            if (Symptom != null)
            {
                SymptomDTO result = new SymptomDTO(Symptom.Id.Value, Symptom.Code, Symptom.Name, Symptom.ShortDescription, Symptom.LongDescription);
                returnList = [result];
            }

            return new GetSymptomResult(
                new PaginatedResult<SymptomDTO>(0, 1, totalCount, returnList));
        }
    }
}