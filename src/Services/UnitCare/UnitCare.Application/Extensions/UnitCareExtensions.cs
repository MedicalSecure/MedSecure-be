namespace UnitCare.Application.Extensions
{
    public static partial class UnitCareExtensions
    {
        public static IEnumerable<UnitCareDto> ToUnitCareDto(this IEnumerable<Domain.Models.UnitCare> unitCares)
        {
            return unitCares.Select(u => new UnitCareDto(
                            Id: u.Id.Value,
                            Type: u.Type,
                            Description: u.Description,
                            Title: u.Title,
                            Personnels: u.Personnels.Select(pe => new PersonnelDto(
                                Id:pe.Id.Value,
                                UnitCareId: pe.UnitCareId.Value,
                                Name:pe.Name,
                                Shift:pe.Shift,
                                Gender:pe.Gender
                                )).ToList(),
                            Rooms: u.Rooms.Select(r => new RoomDto(
                                             Id: r.Id.Value,
                                             UnitCareId: r.UnitCareId.Value,
                                             RoomNumber: r.RoomNumber,
                                             Status: r.Status,
                                             Equipments: r.Equipments.Select(e => new EquipmentDto(
                                                 Id: e.Id.Value,
                                                 RoomId: e.RoomId.Value,
                                                 Name: e.Name,
                                                 Reference: e.Reference,
                                                 EqStatus:e.EqStatus,
                                                 EqType:e.EqType
                                             )).ToList()
                                         )).ToList()
                        ));
        }
    }
}
