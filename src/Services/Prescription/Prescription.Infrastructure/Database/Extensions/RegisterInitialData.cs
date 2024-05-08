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
            RegisterId RegisterId = RegisterId.Of(new Guid("88888888-8888-8888-8888-888888888888"));

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
                                    subRiskFactor: new List<RiskFactor>()
                                ),
                                RiskFactor.Create(
                                    key: "SiblingHeartDisease (lvl2-2-0child)",
                                    value: "Heart Disease (Sibling)",
                                    code: "HD001-S",
                                    description: "Sibling history of heart disease",
                                    isSelected: false,
                                    type: "Cardiovascular",
                                    icon: "heart-icon.png",
                                    subRiskFactor: new List<RiskFactor>()
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
                    subRiskFactor: new List<RiskFactor>()
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
                    subRiskFactor: new List<RiskFactor>()
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
                    subRiskFactor: new List<RiskFactor>()
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
                    subRiskFactor: new List<RiskFactor>()
                )
            };

            // Create history
            var historyList = new List<History>
            {
                History.Create(new DateTime(2022, 5, 15), Status.Resident,RegisterId),
                History.Create(new DateTime(2023, 2, 1), Status.Out, RegisterId)
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