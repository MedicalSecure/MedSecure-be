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
        private static readonly string registerId = "88888888-8888-8888-8888-888888888888";

        //Register

        public static Register GetRegisterInitialData()
        {
            RegisterId RegisterId = RegisterId.Of(Guid.Parse(registerId));

            // Create family medical history
            var familyHistory = new List<RiskFactor>
            {
                RiskFactor.Create(
                    key: "FamilyHistory1 (lvl0-1-1child)",
                    value: "Heart Disease",
                    code: "FH001",
                    description: "Family history of heart disease",
                    isSelected: true,
                    type: "Cardiovascular",
                    icon: "heart-icon.png",
                    subRiskFactor: new List<RiskFactor>
                    {
                        RiskFactor.Create(
                            key: "Heart Diseases (lvl1-1-2child)",
                            value: "Heart Disease",
                            code: "HD001",
                            description: "Family history of heart disease",
                            isSelected: false,
                            type: "Cardiovascular",
                            icon: "heart-icon.png",
                            subRiskFactor: new List<RiskFactor>
                            {
                                RiskFactor.Create(
                                    key: "ParentalHeartDisease (lvl2-1-0child)",
                                    value: "Heart Disease (Parental)",
                                    code: "HD001-P",
                                    description: "Parental history of heart disease",
                                    isSelected: false,
                                    type: "Cardiovascular",
                                    icon: "heart-icon.png",
                                    subRiskFactor: []
                                ),
                                RiskFactor.Create(
                                    key: "SiblingHeartDisease (lvl2-2-0child)",
                                    value: "Heart Disease (Sibling)",
                                    code: "HD001-S",
                                    description: "Sibling history of heart disease",
                                    isSelected: false,
                                    type: "Cardiovascular",
                                    icon: "heart-icon.png",
                                    subRiskFactor: []
                                )
                            }
                        )
                    }
                ),
                RiskFactor.Create(
                    key: "FamilyHistory2",
                    value: "Diabetes",
                    code: "FH002",
                    description: "Family history of diabetes",
                    isSelected: true,
                    type: "Metabolic",
                    icon: "diabetes-icon.png",
                    subRiskFactor: []
                )
            };

            // Create personal medical history
            var personalHistory = new List<RiskFactor>
            {
                RiskFactor.Create(
                    key: "PersonalHistory1",
                    value: "Asthma",
                    code: "PH001",
                    description: "Personal history of asthma",
                    isSelected: true,
                    type: "Respiratory",
                    icon: "asthma-icon.png",
                    subRiskFactor: []
                )
            };

            // Create diseases
            var diseases = new List<RiskFactor>
            {
                RiskFactor.Create(
                    key: "Disease1",
                    value: "Hypertension",
                    code: "D001",
                    description: "Diagnosed with hypertension",
                    isSelected: true,
                    type: "Cardiovascular",
                    icon: "hypertension-icon.png",
                    subRiskFactor: []
                )
            };

            // Create allergies
            var allergies = new List<RiskFactor>
            {
                RiskFactor.Create(
                    key: "Allergy1",
                    value: "Peanut Allergy",
                    code: "A001",
                    description: "Allergic to peanuts",
                    isSelected: true,
                    type: "Food",
                    icon: "peanut-icon.png",
                    subRiskFactor: []
                )
            };

            // Create history
            var historyList = new List<History>
            {
                History.Create(RegisterId, HistoryStatus.Resident,new DateTime(2022, 5, 15)),
                History.Create(RegisterId, HistoryStatus.Out,new DateTime(2023, 2, 1))
            };

            var testList = new List<Test>
            {
                Test.Create(RegisterId,"T001", "Complete Blood Count", Language.English, TestType.LabTest),
                Test.Create(RegisterId,"T002", "Physical Examination", Language.French, TestType.ClinicTest)
            };

            // Create Register instance with static data
            /*var register = Register.Create(RegisterId, patient);

            register.AddFamilyMedicalHistory(familyHistory);
            register.AddPersonalMedicalHistory(personalHistory);
            register.AddDisease(diseases);
            register.AddAllergy(allergies);
            register.AddHistory(historyList);
            register.AddTests(testList);*/
            
            // Create Register instance with static data
            var register = Register.Create(
                RegisterId,
                CreatePatients(),
                familyHistory,
                personalHistory,
                diseases,
                allergies,
                historyList,
                testList
            );

            return register;
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
    }
}