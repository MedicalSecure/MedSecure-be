using UnitCare.Domain.Models;

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
                        type: "General",
                        unitStatus: UnitStatus.activated);

                    // Create personnels for each unitCare
                    var TestPersonnel = Personnel.Create(PersonnelId.Of(Guid.NewGuid()), unitCare.Id, "olivier", Shift.day, Gender.male);
                    var Test2Personnel = Personnel.Create(PersonnelId.Of(Guid.NewGuid()), unitCare.Id, "emily", Shift.night, Gender.female);

                    // Create rooms for each unitCare
                    var TestRomm = Room.Create(RoomId.Of(Guid.NewGuid()), unitCare.Id, 102, Status.pending);
                    var Test2Romm = Room.Create(RoomId.Of(Guid.NewGuid()), unitCare.Id, 103, Status.pending);

                    // Create equipments for each room
                    var TestRommEquipments = new List<Equipment>
            {
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "Bed",
                    reference: "253DMT",
                    eqStatus:EqStatus.nonAvailable,
                    eqType:EqType.bed),
                 Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "TABLE",
                    reference: "25354DMT",
                    eqStatus:EqStatus.available,
                    eqType:EqType.operatingTables),
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: TestRomm.Id,
                    name: "Respirateurs",
                    reference: "21354DMT",
                    eqStatus:EqStatus.nonAvailable,
                    eqType : EqType.vitalSignsMonitors),
            };

                    var Test2RommEquipments = new List<Equipment>
              {
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Matériel de perfusion ",
                    reference: "253DMT",
                    eqStatus:EqStatus.nonAvailable,
                    eqType:EqType.wheelchair),
                 Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Défibrillateurs",
                    reference: "25354DMT",
                    eqStatus:EqStatus.nonAvailable,
                    eqType : EqType.isolationGown),
                Equipment.Create(
                    id: EquipmentId.Of(Guid.NewGuid()),
                    roomId: Test2Romm.Id,
                    name: "Bed",
                    reference: "21354DMT",
                    eqStatus:EqStatus.available,
                    eqType : EqType.bloodPressureCuffs),
            };

                    // Add equipments to respective rooms
                    foreach (var equipment in TestRommEquipments)
                        TestRomm.AddEquipment(equipment);

                    foreach (var equipment in Test2RommEquipments)
                        Test2Romm.AddEquipment(equipment);

                    // Add rooms to unitCare
                    unitCare.AddRoom(TestRomm);
                    unitCare.AddRoom(Test2Romm);
                    unitCare.AddPersonnel(TestPersonnel);
                    unitCare.AddPersonnel(Test2Personnel);

                    return new List<Domain.Models.UnitCare> { unitCare };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.UnitCare), ex.Message);
                }
            }
        }

        public static IEnumerable<Domain.Models.Task> Tasks
        {
            get
            {
                try
                {
                    // Create the task instance
                    var task = Domain.Models.Task.Create(
                        id: TaskId.Of(Guid.NewGuid()),
                        content: "task number 1 ",
                        taskAction: TaskAction.done,
                        taskState: TaskState.pending);

                    return new List<Domain.Models.Task> { task };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Task), ex.Message);
                }
            }
        }
    }
}