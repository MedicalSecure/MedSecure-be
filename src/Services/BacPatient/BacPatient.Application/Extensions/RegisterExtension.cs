using BacPatient.Domain.Models.RegisterRoot;
using rescription.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{
    public static class RegisterExtension
    {
         public static RegisterDto ToRegisterDto(this Register? register)
        {
            if (register == null)
            {
                
                throw new ArgumentNullException(nameof(register), "Cannot convert null register to RegisterDto.");
            }

            return DtoFromRegister(register);
        }


        private static RegisterDto DtoFromRegister(Register register)
        {
            return new RegisterDto(
                id: register.Id,
                patient: new PatientDto(
                    id: register.Patient.Id.Value,
                    firstName: register.Patient.FirstName,
                    lastName: register.Patient.LastName,
                    dateOfBirth: register.Patient.DateOfBirth,
                    identity: register.Patient.Identity,
                    cnam: register.Patient.CNAM,
                    assurance: register.Patient.Assurance,
                    gender: register.Patient.Gender,
                    height: register.Patient.Height,
                    weight: register.Patient.Weight,
                    addressIsRegistrations: register.Patient.AddressIsRegisterations,
                    saveForNextTime: register.Patient.SaveForNextTime,
                    email: register.Patient.Email,
                    address1: register.Patient.Address1,
                    address2: register.Patient.Address2,
                    country: register.Patient.Country,
                    state: register.Patient.State,
                    zipCode: register.Patient.ZipCode,
                    familyStatus: register.Patient.FamilyStatus,
                    children: register.Patient.Children
                ));

        }

        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Register> registers)
        {
            return registers.Select(r => DtoFromRegister(r)).ToList();
        }
    }

       
    }
