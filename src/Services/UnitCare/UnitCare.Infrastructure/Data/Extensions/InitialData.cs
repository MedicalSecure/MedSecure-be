namespace UnitCare.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
      
        public static IEnumerable<Domain.Models.UnitCare> UnitCares
        {
            get
            {
                try
                {
                    // Create the unitCare instance
                    var unitCare = Domain.Models.UnitCare.Create(
                        id: UnitCareId.Of(Guid.NewGuid()),
                        title: "Unit1",
                        description: "this is the first unit",
                        type: "General");

                    // Create rooms for each unitCare
                    var TestRomm = Room.Create(RoomId.Of(Guid.NewGuid()), unitCare.Id, 102, Status.pending);
                    var Test2Romm = Room.Create(RoomId.Of(Guid.NewGuid()), unitCare.Id, 103, Status.pending);


                    // Create equipments for each room
                    var TestRommEquipments = new List<Equipment>
            {
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "bed",
                    reference: "253DMT"),
                 Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "Défibrillateurs",
                    reference: "25354DMT"),
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "Respirateurs",
                    reference: "21354DMT"),
            };

                    var Test2RommEquipments = new List<Equipment>
              {
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Matériel de perfusion ",
                    reference: "253DMT"),
                 Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Défibrillateurs",
                    reference: "25354DMT"),
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Respirateurs",
                    reference: "21354DMT"),
            };

                  
                    // Add equipments to respective rooms
                    foreach (var equipment in TestRommEquipments)
                        TestRomm.AddEquipment(equipment);

                    foreach (var equipment in Test2RommEquipments)
                        Test2Romm.AddEquipment(equipment);

                    // Add rooms to unitCare
                    unitCare.AddRoom(TestRomm);
                    unitCare.AddRoom(Test2Romm);
                  

                    return new List<Domain.Models.UnitCare> { unitCare };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.UnitCare), ex.Message);
                }
            }
        }



    }
}