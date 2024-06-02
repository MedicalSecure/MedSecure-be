using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.UnitCare.Queries
{
    public record GetOccupiedRoomsQuery(PaginationRequest PaginationRequest) : IQuery<GetOccupiedRoomsResult>;
    public record GetOccupiedRoomsResult(PaginatedResult<EquipmentId> OccupiedRooms);

    public class GetOccupiedRoomsQueryValidator : AbstractValidator<GetOccupiedRoomsQuery>
    {
        public GetOccupiedRoomsQueryValidator()
        {
        }
    }
}