using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Infrastructure.Database.Extensions
{
    public static class RegisterInitialData
    {
        public static Register GetRegisterInitialData(Patient patient)
        {
            Guid RegisterId = new Guid("88888888-8888-8888-8888-888888888888");

            // Create family medical history
            var familyHistory = new List<RiskFactor>
            {
                new RiskFactor
                {
                    Key = "FamilyHistory1 (lvl0-1-1child)",
                    Value = "Heart Disease",
                    Code = "FH001",
                    Description = "Family history of heart disease",
                    IsSelected = true,
                    Type = "Cardiovascular",
                    Icon = "heart-icon.png",
                    SubRiskFactor = new List<RiskFactor>
                    {
                            new RiskFactor
                            {
                                Key = "Heart Diseases (lvl1-1-2child)",
                                Value = "Heart Disease",
                                Code = "HD001",
                                Description = "Family history of heart disease",
                                IsSelected = false,
                                Type = "Cardiovascular",
                                Icon = "heart-icon.png",
                                SubRiskFactor = new List<RiskFactor>
                                {
                                    new RiskFactor
                                    {
                                        Key = "ParentalHeartDisease (lvl2-1-0child)",
                                        Value = "Heart Disease (Parental)",
                                        Code = "HD001-P",
                                        Description = "Parental history of heart disease",
                                        IsSelected = false,
                                        Type = "Cardiovascular",
                                        Icon = "heart-icon.png",
                                        SubRiskFactor = new List<RiskFactor>()
                                    },
                                    new RiskFactor
                                    {
                                        Key = "SiblingHeartDisease (lvl2-2-0child)",
                                        Value = "Heart Disease (Sibling)",
                                        Code = "HD001-S",
                                        Description = "Sibling history of heart disease",
                                        IsSelected = false,
                                        Type = "Cardiovascular",
                                        Icon = "heart-icon.png",
                                        SubRiskFactor = new List<RiskFactor>()
                                    }
                                }
                            }
                    }
                },
                new RiskFactor
                {
                    Key = "FamilyHistory2",
                    Value = "Diabetes",
                    Code = "FH002",
                    Description = "Family history of diabetes",
                    IsSelected = true,
                    Type = "Metabolic",
                    Icon = "diabetes-icon.png",
                    SubRiskFactor = new List<RiskFactor>()
                }
            };

            // Create personal medical history
            var personalHistory = new List<RiskFactor>
            {
                new RiskFactor
                {
                    Key = "PersonalHistory1",
                    Value = "Asthma",
                    Code = "PH001",
                    Description = "Personal history of asthma",
                    IsSelected = true,
                    Type = "Respiratory",
                    Icon = "asthma-icon.png",
                    SubRiskFactor = new List<RiskFactor>()
                }
            };

            // Create diseases
            var diseases = new List<RiskFactor>
            {
                new RiskFactor
                {
                    Key = "Disease1",
                    Value = "Hypertension",
                    Code = "D001",
                    Description = "Diagnosed with hypertension",
                    IsSelected = true,
                    Type = "Cardiovascular",
                    Icon = "hypertension-icon.png",
                    SubRiskFactor = new List<RiskFactor>()
                }
            };

            // Create allergies
            var allergies = new List<RiskFactor>
            {
                new RiskFactor
                {
                    Key = "Allergy1",
                    Value = "Peanut Allergy",
                    Code = "A001",
                    Description = "Allergic to peanuts",
                    IsSelected = true,
                    Type = "Food",
                    Icon = "peanut-icon.png",
                    SubRiskFactor = new List<RiskFactor>()
                }
            };

            // Create history
            var historyList = new List<History>
            {
                History.Create(new DateTime(2022, 5, 15), Status.Resident, patient.Id),
                History.Create(new DateTime(2023, 2, 1), Status.Out, patient.Id)
            };

            var testList = new List<Test>
            {
                Test.Create(RegisterId,"T001", "Complete Blood Count", Language.English, TestType.LabTest),
                Test.Create(RegisterId,"T002", "Physical Examination", Language.French, TestType.ClinicTest)
            };

            // Create Register instance with static data
            var register = Register.Create(
                RegisterId,
                patient,
                familyHistory,
                personalHistory,
                diseases,
                allergies,
                historyList,
                null, // Prescriptions list is set to null
                testList
            );
            return register;
        }
    }
}