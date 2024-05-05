using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record RegisterDto
    {
        public Guid Id { get; init; }
        public Guid PatientId { get; init; }
        public PatientDto Patient { get; init; }
        public List<RiskFactor>? FamilyMedicalHistory { get; init; }
        public List<RiskFactor>? PersonalMedicalHistory { get; init; }
        public List<RiskFactor>? Diseases { get; init; }
        public List<RiskFactor>? Allergies { get; init; }
        public List<History>? History { get; init; }
        public List<Test>? Test { get; init; }
        public List<PrescriptionDto>? Prescriptions { get; init; }

        public RegisterDto() { }
        public RegisterDto(
           Guid id,
           Guid patientId,
           PatientDto patient,
           List<RiskFactor>? familyMedicalHistory = null,
           List<RiskFactor>? personalMedicalHistory = null,
           List<RiskFactor>? diseases = null,
           List<RiskFactor>? allergies = null,
           List<History>? history = null,
           List<Test>? test = null,
           List<PrescriptionDto>? prescriptions = null)
        {
            Id = id;
            PatientId = patientId;
            Patient = patient;
            FamilyMedicalHistory = familyMedicalHistory;
            PersonalMedicalHistory = personalMedicalHistory;
            Diseases = diseases;
            Allergies = allergies;
            History = history;
            Test = test;
            Prescriptions = prescriptions;
        }
    }
}