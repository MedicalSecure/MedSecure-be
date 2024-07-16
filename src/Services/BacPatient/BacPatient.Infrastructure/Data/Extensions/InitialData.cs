

namespace BacPatient.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId1 = "7506213d-3b5f-4498-b35c-9169a600ff10";
        private static readonly string registerId = "88888888-8888-8888-8888-888888888888";

        //Register

        public static Register GetRegisterInitialData()
        {
            RegisterId RegisterId = RegisterId.Of(Guid.Parse(registerId));

     
            // Create Register instance with static data
            var register = Register.Create(
                RegisterId,
                Patient.Create(firstName:"john" , lastName :"doe",dateOfbirth: new DateTime(1990, 1, 1))
              
            );

            return register;
        }

     
    }
}