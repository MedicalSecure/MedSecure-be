using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Domain.Enums;

namespace UnitCare.Application.Dtos
{
    public record RoomDto(Guid Id, Guid UnitCareId, decimal RoomNumber, Status Status, List<EquipmentDto> Equipments);
}
