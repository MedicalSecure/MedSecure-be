﻿
namespace BacPatient.Application.Dtos
{
    public record RoomDto(Guid Id, Guid UnitCareId, decimal? RoomNumber, Status? Status, EquipmentDto Equipments);
}
