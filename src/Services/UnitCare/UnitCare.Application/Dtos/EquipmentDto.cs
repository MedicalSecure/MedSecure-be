using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Dtos
{
    public record EquipmentDto(Guid Id, Guid RoomId, string Name, string Reference);
}
