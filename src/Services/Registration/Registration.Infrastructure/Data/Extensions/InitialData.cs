using Registration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        //public AssociatedPatientId patientId = "123-";
        public static IEnumerable<Register> Registers
        {
            get
            {
                try
                {
                    var patients = Patients.ToList();
                    var smokingRisk = CreateRiskFactorForSmoking();
                    var familyHistoryRisk = CreateRiskFactorForFamilyHistory();
                    var obesityRisk = CreateRiskFactorForObesity();

                    return new List<Register>
                    {
                        Register.Create(
                            id: RegisterId.Of(Guid.NewGuid()),
                            patient: patients.First()
                        )
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Register), ex.Message);
                }
            }
        }

        public static IEnumerable<Patient> Patients
        {
            get
            {
                try
                {
                    var patientId = PatientId.Of(Guid.NewGuid());
                    return new List<Patient>
                    {
                        Patient.Create(
                            id: patientId,
                            firstName: "John",
                            lastName: "Doe",
                            dateOfBirth: new DateTime(1990, 1, 1),
                            cin: 123456,
                            cnam: 789012,
                            assurance: "",
                            gender: Gender.Male,
                            height: 180,
                            weight: 75,
                            addressIsRegisterations:true,
                            saveForNextTime:true,
                            email: "john.doe@example.com",
                            address1: "Address Line 1",
                            address2: "Address Line 2",
                            country: Country.VN,
                            state: "State",
                            zipCode: 1222,
                            familyStatus: FamilyStatus.MARRIED,
                            children: Children.ThreeOrMore
                        )
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        private static RiskFactor CreateRiskFactorForSmoking()
        {
            var cc = RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Smoking",
                value: "Yes",
                code: "SMK001",
                description: "Smoking Description",
                isSelected: true,
                type: "Smoking Type",
                icon: "Smoking Icon");

            //cc.SubRiskfactor.cre = RiskFactor.Create()
            //    subRiskFactor: new List<RiskFactor>
            //    {
            //        RiskFactor.Create(
            //            id: RiskFactorId.Of(Guid.NewGuid()),
            //            key: "Lung Cancer",
            //            value: "Increased Risk",
            //            code: "LC001",
            //            description: "Lung Cancer Description",
            //            isSelected: false,
            //            type: "Lung Cancer Type",
            //            icon: "Lung Cancer Icon"

            //        ),
            //        RiskFactor.Create(
            //            id: RiskFactorId.Of(Guid.NewGuid()),
            //            key: "Heart Disease",
            //            value: "Increased Risk",
            //            code: "HD001",
            //            description: "Heart Disease Description",
            //            isSelected: false,
            //            type: "Heart Disease Type",
            //            icon: "Heart Disease Icon"

            //        )
            //    }

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
                icon: "Family History Icon"
                
            );
        }

        private static RiskFactor CreateRiskFactorForObesity()
        {
            return RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: "Obesity (BMI > 30)",
                value: "Yes",
                code: "OB001",
                description: "Obesity Description",
                isSelected: true,
                type: "Obesity Type",
                icon: "Obesity Icon"
                //subRiskFactor: new List<RiskFactor>
                //{
                //    RiskFactor.Create(
                //        id: RiskFactorId.Of(Guid.NewGuid()),
                //        key: "Type 2 Diabetes",
                //        value: "Increased Risk",
                //        code: "T2D001",
                //        description: "Type 2 Diabetes Description",
                //        isSelected: false,
                //        type: "Type 2 Diabetes Type",
                //        icon: "Type 2 Diabetes Icon",
                //        subRiskFactor: new List<RiskFactor>()
                //    )
                //}
            );
        }
    }
}
