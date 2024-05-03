using System.Linq;

namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                Id : d.Id,
                Register : d.Register.ToRegisterDto(),
                UnitCare:d.UnitCare.ToUnitCareDto(),
                Bed : d.Bed ,
                NurseId : d.NurseId , 
                Served : d.Served ,
                ToServe : d.ToServe , 
                Status : d.Status 
                ));
          
        }
    }
}
