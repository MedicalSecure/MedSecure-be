using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.UnitCares.Queries.GetUnitCares;


    public record GetUnitCaresQuery(PaginationRequest PaginationRequest)
: IQuery<GetUnitCaresResult>;

    public record GetUnitCaresResult(PaginatedResult<UnitCareDto> UnitCares);

