using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Dtos
{
    public record UnitCareDto(Guid Id, string Type, string Description, string Title, List<RoomDto> Rooms);
}
