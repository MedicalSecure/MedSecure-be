using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions.SimpleBacPatientExtension
{
    public static class SimplePrescriptionExtension
    {
        public static SimplePrescriptionDto ToSimplePrescriptionDto(this Prescription pres)
        {
            var x = new SimplePrescriptionDto(
                Id: pres.Id,
                Register: pres.Register.ToSimpleRegisterDto()
                
            );
            return x;
        }
        public static SimpleRegisterDto ToSimpleRegisterDto(this Register register)
        {
            return new SimpleRegisterDto
            {
                Id = register.Id,
              
                Patient = register.Patient.ToSimplePatientDto(),
                   };
        }
        public static SimplePatientDto ToSimplePatientDto(this Patient patient)
        {
            return new SimplePatientDto(
                Id: patient.Id,
                FirstName: patient.FirstName,
                LastName: patient.LastName,
                DateOfbirth: patient.DateOfBirth,
                Gender: patient.Gender
            );
        }
    }
}
