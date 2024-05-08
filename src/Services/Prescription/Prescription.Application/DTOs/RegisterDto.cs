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
        public List<RiskFactorDto>? FamilyMedicalHistory { get; init; }
        public List<RiskFactorDto>? PersonalMedicalHistory { get; init; }
        public List<RiskFactorDto>? Diseases { get; init; }
        public List<RiskFactorDto>? Allergies { get; init; }
        public List<History>? History { get; init; }
        public List<Test>? Test { get; init; }
        public List<PrescriptionDto>? Prescriptions { get; init; }

        public RegisterDto() { }
        public RegisterDto(
           RegisterId id,
           PatientId patientId,
           PatientDto patient,
           List<RiskFactorDto>? familyMedicalHistory = null,
           List<RiskFactorDto>? personalMedicalHistory = null,
           List<RiskFactorDto>? diseases = null,
           List<RiskFactorDto>? allergies = null,
           List<History>? history = null,
           List<Test>? test = null,
           List<PrescriptionDto>? prescriptions = null)
        {
            Id = id.Value;
            PatientId = patientId.Value;
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