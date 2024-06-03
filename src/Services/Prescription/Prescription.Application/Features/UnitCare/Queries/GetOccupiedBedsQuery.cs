using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.UnitCare.Queries
{
    public record GetOccupiedBedsQuery(PaginationRequest PaginationRequest) : IQuery<GetOccupiedBedsResult>;
    public record GetOccupiedBedsResult(PaginatedResult<EquipmentId> OccupiedRooms);

    public class GetOccupiedRoomsQueryValidator : AbstractValidator<GetOccupiedBedsQuery>
    {
        public GetOccupiedRoomsQueryValidator()
        {
        }
    }
}