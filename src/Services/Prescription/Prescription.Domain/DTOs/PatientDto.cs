﻿using Prescription.Domain.Entities;
using Prescription.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.DTOs
{
    public record PatientDto
    {
        public Guid Id { get; }
        public string PatientName { get; }
        public DateTime DateOfBirth { get; }
        public Gender Gender { get; }
        public int Height { get; }
        public int Weight { get; }
        public Register Register { get; }
        public RiskFactor RiskFactor { get; }
        public RiskFactor Disease { get; }

        // Primary constructor
        public PatientDto(Guid id, string patientName, DateTime dateOfBirth, Gender gender, int height, int weight, Register register, RiskFactor riskFactor, RiskFactor disease)
        {
            Id = id;
            PatientName = patientName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Height = height;
            Weight = weight;
            Register = register;
            RiskFactor = riskFactor;
            Disease = disease;
        }

        // Default constructor
        public PatientDto()
        {
        }
    }
}