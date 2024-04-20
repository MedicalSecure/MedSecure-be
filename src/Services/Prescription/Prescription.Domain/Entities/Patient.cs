using Microsoft.Win32;
using Prescription.Domain.Entities.Prescription;
using Prescription.Domain.Enums;

namespace Prescription.Domain.Entities
{
    public class Patient : Aggregate<Guid>
    {
        public string PatientName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Weight { get; set; } = default!;
        public Register Register { get; set; } = default!;
        public RiskFactor RiskFactor { get; set; } = default!;
        public RiskFactor Disease { get; set; } = default!;

        public Patient()
        { } // For EF

        public static Patient Create(Guid id, string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            var patient = new Patient
            {
                PatientName = patientName,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Height = height,
                Weight = weight,
                Register = register,
                RiskFactor = riskFactor,
                Disease = disease
            };
            // patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }

        public static Patient Create(string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            var patient = new Patient
            {
                PatientName = patientName,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Height = height,
                Weight = weight,
                Register = register,
                RiskFactor = riskFactor,
                Disease = disease
            };
            // patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }
    }

    public class Register
    {
        public List<RiskFactor> familymedicalhistory { get; set; }
        public List<RiskFactor> personalMedicalHistory { get; set; }
    }

    public class RiskFactor
    {
        public string key { get; set; }
        public string value { get; set; }
        public List<RiskFactor> subRiskfactory { get; set; }
    }
}