

using Microsoft.VisualBasic.FileIO;

namespace BacPatient.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        private static readonly string roomId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        private static readonly string unitCareId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        public static IEnumerable<Domain.Models.BacPatient> BacPatients
        {
            get
            {
                try
                {
                    var bp = Domain.Models.BacPatient.Create(
                        Id: BacPatienId.Of(Guid.NewGuid()),
                        PatientId: PatientId.Of(new Guid(patientId)),
                        RoomId : RoomId.Of(new Guid(roomId)),
                        UnitCareId: UnitCareId.Of(new Guid(unitCareId)),
                        Bed : 1,
                        ServingDate : DateTime.Now,
                        Served : 3,
                        ToServe : 5,
                        Status: BacPatient.Domain.Enums.StatusBP.Pending);

                    var medecines = new List<Medicine>
                    {
                         Medicine.Create(
                         Id: MedicineId.Of(Guid.NewGuid()),
                        Name : "jlkncdnjqf",
                        Forme:"ef,klff,evf",
                        Dose:"fvdnv:v",
                        Unit:"njkdcnjvf",
                        DateExp:DateTime.Now,
                        Stock:12,
                        Note:["blabla"]
                        
                         )

                    };

                    var posologies = new List<Posology> {

                        Posology.Create(
                        Id: PoslogyId.Of(Guid.NewGuid()),
                        StartDate:DateTime.Now,
                        EndDate:DateTime.Now,
                        QuantityAE:15,
                        QuantityBE:12,
                        IsPermanent:false,
                        Hours:["1,2,3"]
                         )
                    };
                    foreach (var med in medecines)
                    {
                        bp.AddMedicne(med);
                        foreach (var pos in posologies)
                            med.AddPosology(pos);
                    }
                       
                    return new List<Domain.Models.BacPatient> { bp };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.BacPatient), ex.Message);
                }
            }
        }
        public static IEnumerable<Patient> Patients
        {
            get
            {
                try
                {
                   
                    var bp = Patient.Create(
                        Id: PatientId.Of(new Guid(patientId)),
                        Name: "mehrez",
                        DateOfBirth:DateTime.Now ,
                        Gender:"male" ,
                        Age:1,
                        Height:180,
                        Weight:75,
                        ActivityStatus: "blabla",
                        Allergies: ["blabla"],
                        RiskFactor: "blabla",
                        FamilyHistory: "blabla") ;
            


                    return new List<Patient> { bp };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        public static IEnumerable<Room> Rooms
        {
            get
            {
                try
                {

                    var bp = Room.Create(
                        id: RoomId.Of(new Guid(roomId)),
                        number:3,
                       status: Domain.Enums.Status.available,
                       beds: [1,2,3,4]
                  );

                    return new List<Room> { bp };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Room), ex.Message);
                }
            }
        }
        public static IEnumerable<UnitCare> UnitCares
        {
            get
            {
                try
                {

                    var bp = UnitCare.Create(
                        Id: UnitCareId.Of(new Guid(unitCareId)),
                        Title: "wiw",
                        Type:"wiiiw",
                        Description:"wiiiiiiw",
                        Status:Domain.Enums.Status.available
                      
                  );

                    return new List<UnitCare> { bp };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(UnitCare), ex.Message);
                }
            }
        }

    }
}
