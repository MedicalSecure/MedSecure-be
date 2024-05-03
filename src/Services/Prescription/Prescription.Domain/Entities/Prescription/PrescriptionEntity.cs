﻿using System.Numerics;

namespace Prescription.Domain.Entities.Prescription
{
    public class PrescriptionEntity : Aggregate<Guid>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();
        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();
        public Guid RegisterId { get; private set; }
        public Register? Register { get; private set; }
        public Guid DoctorId { get; private set; }

        public Doctor? Doctor { get; private set; }

        private PrescriptionEntity()
        { }// for EF

        private PrescriptionEntity(Guid id, Register? r, Guid registerId, Doctor? D, Guid doctorId, DateTime createdAt = default)
        {
            Id = id;
            Register = r;
            RegisterId = registerId;
            Doctor = D;
            DoctorId = doctorId;
            CreatedBy = doctorId.ToString();
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }

        public static PrescriptionEntity Create(Register r, Doctor doctor, DateTime createdAt = default)
        {
            //validations here
            //..
            //..

            // Newly created prescription
            Guid PrescriptionId = new Guid();
            return new PrescriptionEntity(PrescriptionId, r, r.Id, doctor, doctor.Id, createdAt);
        }

        public static PrescriptionEntity Create(Guid PrescriptionId, Register r, Doctor doctor, DateTime createdAt = default)
        {
            //validations here
            //..
            //..
            return new PrescriptionEntity(PrescriptionId, r, r.Id, doctor, doctor.Id, createdAt);
        }

        public bool addPosology(Posology posology)
        {
            this._posology.Add(posology);
            return true;
        }

        public bool addDiagnosis(Diagnosis diagnosis)
        {
            this._diagnosis.Add(diagnosis);
            return true;
        }

        public bool addDiagnosis(ICollection<Diagnosis> diagnosis)
        {
            foreach (Diagnosis diagnosisItem in diagnosis)
                this._diagnosis.Add(diagnosisItem);
            return true;
        }

        public bool addSymptom(Symptom symptom)
        {
            this._symptoms.Add(symptom);
            return true;
        }

        public bool addSymptoms(ICollection<Symptom> symptoms)
        {
            foreach (Symptom symptom in symptoms)
                this._symptoms.Add(symptom);
            return true;
        }
    }
}