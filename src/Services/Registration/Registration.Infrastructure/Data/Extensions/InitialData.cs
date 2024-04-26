

using Registration.Domain.Models;

namespace Registration.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string patientId = "7506213d-3b5f-4498-b35c-9169a600ff10";

        /// <summary>
        /// Retrieves a collection of patients with their details.
        /// </summary>


        public static IEnumerable<Register> Registers
        {
            get
            {
                try
                {
                    return new List<Register>
                    {
                        // Create Patient instances
                        Register.Create(
                             id: RegisterId.Of(Guid.NewGuid()),
                             patientId: PatientId.Of(new Guid()),
                             patient:new Patient(),
                              familyHistory: new List<RiskFactor>(), // Empty list
                              personalHistory: new List<RiskFactor>(), // Empty list
                              disease: new List<RiskFactor>(),
                              allergy: new List<RiskFactor>()
                            ),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }
        public static IEnumerable<RiskFactor> RiskFactors
        {
            get
            {
                yield return CreateRiskFactorForSmoking();
                yield return CreateRiskFactorForFamilyHistory();
                yield return CreateRiskFactorForObesity();
            }
        }

        private static RiskFactor CreateRiskFactorForSmoking()
        {
            var smokingRiskFactor = RiskFactor.Create(
              id: RiskFactorId.Of(Guid.NewGuid()),
              key: "Smoking",
              value: "Yes",
              subRiskFactor: new List<RiskFactor>()
              {
        RiskFactor.Create(
          id: RiskFactorId.Of(Guid.NewGuid()),
          key: "Lung Cancer",
          value: "Increased Risk",
          subRiskFactor: new List<RiskFactor>() { }
        ),
        RiskFactor.Create(
          id: RiskFactorId.Of(Guid.NewGuid()),
          key: "Heart Disease",
          value: "Increased Risk",
          subRiskFactor: new List<RiskFactor>() { }
        )
              }
            );

            return smokingRiskFactor;
        }

        private static RiskFactor CreateRiskFactorForFamilyHistory()
        {
            var familyHistoryRiskFactor = RiskFactor.Create(
              id: RiskFactorId.Of(Guid.NewGuid()),
              key: "Family History of Heart Disease",
              value: "Yes",
              subRiskFactor: new List<RiskFactor>() { }
            );

            return familyHistoryRiskFactor;
        }

        private static RiskFactor CreateRiskFactorForObesity()
        {
            var obesityRiskFactor = RiskFactor.Create(
              id: RiskFactorId.Of(Guid.NewGuid()),
              key: "Obesity (BMI > 30)",
              value: "Yes",
              subRiskFactor: new List<RiskFactor>()
              {
        RiskFactor.Create(
          id: RiskFactorId.Of(Guid.NewGuid()),
          key: "Type 2 Diabetes",
          value: "Increased Risk",
          subRiskFactor: new List<RiskFactor>() { }
        )
              }
            );

            return obesityRiskFactor;
        }
    }

}
