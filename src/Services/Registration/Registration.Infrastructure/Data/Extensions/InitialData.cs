using Mapster.Utils;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId1 = "7506213d-3b5f-4498-b35c-9169a600ff10";
        private static readonly string registerId = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";
        private static readonly string historyId = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";
        private static readonly string testId = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";
        //Register
        public static IEnumerable<Register> Registers
        {
            get
            {
                try
                {
                    var patient = CreatePatients();
                    var familyHistoryRisk = CreateRiskFactorForFamilyHistory();
                    var personalMedicalHistory = CreateRiskFactorForPersonalMedicalHistroy();
                    var disease = CreateRiskFactorForDiseases();
                    var allergy = CreateRiskFactorForAllergies();
                    var history = CreateHistory();
                    var test = CreateTest();
                    

                    // Create a new Register instance
                    var register = Register.Create(
                        id: RegisterId.Of(Guid.Parse(registerId)),
                        patient: patient
                    );
                

                    // Add additional properties
                    register.AddFamilyMedicalHistory(familyHistoryRisk);
                    register.AddPersonalMedicalHistory(personalMedicalHistory); 
                    register.AddDisease(disease); 
                    register.AddAllergy(allergy); 
                    register.AddHistory(history);
                    register.AddTests(test);

                    return new List<Register> { register };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Register), ex.Message);
                }
            }
        }

        private static Patient CreatePatients()
        {
            return Patient.Create(
                            PatientId.Of(Guid.Parse(patientId1)),
                            firstName: "John",
                            lastName: "Doe",
                            dateOfBirth: new DateTime(1990, 1, 1),
                            identity: "123456",
                            cnam: 789012,
                            assurance: "",
                            gender: Gender.Male,
                            height: 180,
                            weight: 75,
                            addressIsRegisterations: true,
                            saveForNextTime: true,
                            email: "john.doe@example.com",
                            address1: "Address Line 1",
                            address2: "Address Line 2",
                            country: Country.VN,
                            state: "State",
                            zipCode: 1222,
                            familyStatus: FamilyStatus.MARRIED,
                            children: Children.ThreeOrMore
                        );
        }

        

         //History
        private static History CreateHistory()
        {
            var cc = History.Create(
               id: HistoryId.Of(Guid.Parse(historyId)),
               date: DateTime.Now,
               status: HistoryStatus.Resident,
               registerId: RegisterId.Of(Guid.Parse(registerId)));
            
            return cc;
        }

        private static Test CreateTest()
        {
            var cc = Test.Create(
               id: TestId.Of(Guid.Parse(testId)),
               code: "DateTime.Now",
               description: "Status.Resident",
               language: Language.English,
               type: TestType.ClinicTest,
               registerId: RegisterId.Of(Guid.Parse(registerId)));

            return cc;
        }

        private static RiskFactor CreateRiskFactorForAllergies()
        {
            var cc = RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Smoking",
                value: "Yes",
                code: "SMK001",
                description: "Smoking Description",
                isSelected: true,
                type: "Smoking Type",
                icon: "Smoking Icon",
                registerId : RegisterId.Of(Guid.Parse(registerId)));

            return cc;

        }
        private static RiskFactor CreateRiskFactorForDiseases()
        {
            var cc = RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Smoking",
                value: "Yes",
                code: "SMK001",
                description: "Smoking Description",
                isSelected: true,
                type: "Smoking Type",
                icon: "Smoking Icon",
                registerId: RegisterId.Of(Guid.Parse(registerId)));
            return cc;
            
        }
        private static RiskFactor CreateRiskFactorForFamilyHistory()
        {
            return RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Family History of Heart Disease",
                value: "Yes",
                code: "FH001",
                description: "Family History of Heart Disease Description",
                isSelected: true,
                type: "Family History Type",
                icon: "Family History Icon",
                registerId: RegisterId.Of(Guid.Parse(registerId))
            ) ;
        }
        
        private static RiskFactor CreateRiskFactorForPersonalMedicalHistroy()
        {
            return RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Obesity (BMI > 30)",
                value: "Yes",
                code: "OB001",
                description: "Obesity Description",
                isSelected: true,
                type: "Obesity Type",
                icon: "Obesity Icon",
                registerId: RegisterId.Of(Guid.Parse(registerId))
            );
        }
        
    }
}
