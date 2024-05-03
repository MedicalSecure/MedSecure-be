namespace BacPatient.Application.Extensions
{
    public static class UnitCareExtensions
    {
        public static IEnumerable<UnitCareDto> ToUnitCareDtos(this IEnumerable<Domain.Models.UnitCare> unitCares)
        {
            return unitCares.Select(u => u.ToUnitCareDto());
        }

        public static UnitCareDto ToUnitCareDto(this Domain.Models.UnitCare unitCare)
        {
            return new UnitCareDto(
                Id: unitCare.Id.Value,
                Type: unitCare.Type,
                Description: unitCare.Description,
                Title: unitCare.Title,
                Personnels: unitCare.Personnels.Select(pe => new PersonnelDto(
                    Id: pe.Id.Value,
                    UnitCareId: pe.UnitCareId.Value,
                    Name: pe.Name,
                    Shift: pe.Shift,
                    Gender: pe.Gender
                )).ToList(),
                Rooms: unitCare.Rooms.Select(r => new RoomDto(
                    Id: r.Id.Value,
                    UnitCareId: r.UnitCareId.Value,
                    RoomNumber: r.RoomNumber,
                    Status: r.Status,
                    Equipments: r.Equipments.Select(e => new EquipmentDto(
                        Id: e.Id.Value,
                        RoomId: e.RoomId.Value,
                        Name: e.Name,
                        Reference: e.Reference
                    )).ToList()
                )).ToList()
            );
        }
    }
}
