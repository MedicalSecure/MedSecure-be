using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Application.Visits.Queries.GetVisitById;

public record GetVisitByIdQuery(Guid id) : IQuery<GetVisitByIdResult>;
public record GetVisitByIdResult(IEnumerable<VisitDto> Visits);