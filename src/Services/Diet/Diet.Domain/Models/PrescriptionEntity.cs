

using Diet.Domain.Models.RegisterRoot;
using Diet.Domain.ValueObjects;
using System.Collections.Generic;

namespace Diet.Domain.Models
{

    public class Prescription : Aggregate<PrescriptionId>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();
        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();
        public Guid RegisterId { get; private set; }
        public Register? Register { get; private set; }
        public UnitCare? UnitCare { get; private set; }

         
        public Prescription()
        { }// for EF

        private Prescription(PrescriptionId id, Guid registerId, DateTime? createdAt = default)
        {
            Id = id;
            RegisterId = registerId;
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }
       
        // lil bacPatient
     
        public Prescription( PrescriptionId id , Register register, UnitCare unitCare, DateTime? createdAt = default)
        {
            Id = id;
            Register = register;
            UnitCare = unitCare;
            CreatedAt = createdAt == default ? DateTime.Now : createdAt;
        }
        public static Prescription Create(Guid RegisterId,DateTime? createdAt = default)
        {
            PrescriptionId id = PrescriptionId.Of(Guid.NewGuid());
            return new Prescription(id, RegisterId, createdAt);
        }

        public static Prescription Create(PrescriptionId PrescriptionId, Guid registerId, DateTime createdAt = default)
        {
           
            return new Prescription(PrescriptionId, registerId, createdAt);
        }
     
      
        public bool addPosology(Posology posology)
        {
            this._posology.Add(posology);
            return true;
        }
        public void addPosologies(ICollection<Posology> posologies)
        {
            foreach(var posology in posologies)
            {
                this._posology.Add(posology);

            }

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
  
        //lil bac patient
        public static Prescription Create(Register Register, UnitCare UnitCare , DateTime? CreatedAt  )
        {
            PrescriptionId id = PrescriptionId.Of(Guid.NewGuid());

            return new Prescription(id, Register , UnitCare, CreatedAt );
        }
    }
}