

namespace BacPatient.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        private static readonly string roomId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        private static readonly string unitCareId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        public static IEnumerable<BacPatient.Domain.Models.BPModel> bPModels
        {
            get
            {
                try
                {
                    // Create the diet instance
                    var bp = BPModel.Create(
                        id: BPModelId.Of(Guid.NewGuid()),
                        patientId: PatientId.Of(new Guid(patientId)),
                        roomId : RoomId.Of(new Guid(roomId)),
                        unitCareId: UnitCareId.Of(new Guid(unitCareId)),

                        bed : 1,
                        servingDate : DateTime.Now,
                        served : 3,
                        toServe : 5,
                        status: BacPatient.Domain.Enums.StatusBP.Pending);

               

                 ;

                    return new List<BPModel> { bp };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(BPModel), ex.Message);
                }
            }
        }



    }
}
