#pragma warning disable CS8618 // Disable the warning for non-nullable reference types

namespace Prescription.Domain.Entities
{
    public class Prescription : Aggregate<PrescriptionId>
    {
        private readonly List<Posology> _posology = new();
        private readonly List<Diagnosis> _diagnosis = new();
        private readonly List<Symptom> _symptoms = new();

        public IReadOnlyList<Posology> Posology => _posology.AsReadOnly();
        public IReadOnlyList<Symptom> Symptoms => _symptoms.AsReadOnly();
        public IReadOnlyList<Diagnosis> Diagnosis => _diagnosis.AsReadOnly();

        public EquipmentId? BedId { get; private set; }
        public DietForPrescription? Diet { get; private set; }
        public RegisterId RegisterId { get; private set; }
        public DoctorId DoctorId { get; private set; }

        public PrescriptionStatus Status { get; private set; }

        private Prescription()
        { }// for EF

        private Prescription(PrescriptionId id, RegisterId registerId, DoctorId doctorId, EquipmentId? bedId, DietForPrescription? diet = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            if (bedId == null)
            {
                BedId = null;
                Diet = null;
            }
            else if (bedId != null && diet == null)
            {
                throw new DomainException($"Can't create a prescription without a diet, provided a Null diet but bedId:{bedId}");
            }
            else
            {
                BedId = bedId;
                Diet = diet;
            }
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            Status = status;
        }

        public static Prescription Create(RegisterId RegisterId, DoctorId doctorId, EquipmentId? bedId = null, DietForPrescription? diet = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            PrescriptionId prescriptionId = PrescriptionId.Of(Guid.NewGuid());
            return new Prescription(prescriptionId, RegisterId, doctorId, bedId, diet, status);
        }

        public static Prescription Create(PrescriptionId PrescriptionId, RegisterId registerId, DoctorId doctorId, EquipmentId? bedId, DietForPrescription? diet = null, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            return new Prescription(PrescriptionId, registerId, doctorId, bedId, diet, status);
        }

        public static Prescription CreateNonHospitalized(PrescriptionId PrescriptionId, RegisterId registerId, DoctorId doctorId, PrescriptionStatus status = PrescriptionStatus.Pending)
        {
            return new Prescription(PrescriptionId, registerId, doctorId, null, null, status);
        }

        private bool _IsReadOnly()
        {
            if (Status == PrescriptionStatus.Draft) return false;
            if (Status == PrescriptionStatus.Pending) return false;

            return true;
        }

        public bool AddPosology(Posology posology)
        {
            if (posology.PrescriptionId != Id) return false;
            if (_IsReadOnly()) return false;

            this._posology.Add(posology);
            return true;
        }

        public bool AddDiagnosis(Diagnosis diagnosis)
        {
            if (_IsReadOnly()) return false;
            this._diagnosis.Add(diagnosis);
            return true;
        }

        public bool AddDiagnosis(ICollection<Diagnosis?> diagnosis)
        {
            if (_IsReadOnly()) return false;
            //iterate throught non null items only
            foreach (Diagnosis diagnosisItem in diagnosis.OfType<Diagnosis>())
            {
                this._diagnosis.Add(diagnosisItem);
            }
            return true;
        }

        public bool AddSymptom(Symptom symptom)
        {
            if (_IsReadOnly()) return false;
            this._symptoms.Add(symptom);
            return true;
        }

        public bool AddSymptoms(ICollection<Symptom?> symptoms)
        {
            if (_IsReadOnly()) return false;

            foreach (Symptom? symptom in symptoms)
            {
                if (symptom != null)
                    this._symptoms.Add(symptom);
            }
            return true;
        }

        /*        public bool UpdateStatus(PrescriptionStatus newStatus)
                {
                    if (Status == PrescriptionStatus.Completed || Status == PrescriptionStatus.Discontinued)
                    {
                        return false;
                    }

                    if (Status == PrescriptionStatus.Draft)
                    {
                        var c1 = newStatus == PrescriptionStatus.Draft;
                        var c2 = newStatus == PrescriptionStatus.Pending;
                        if (c1 || c2)
                        {
                            this.Status = newStatus;
                            return true;
                        }
                        return false;
                    }
                    if (Status == PrescriptionStatus.Pending)
                    {
                        var c1 = newStatus == PrescriptionStatus.Rejected;
                        var c2 = newStatus == PrescriptionStatus.Active;
                        var c3 = newStatus == PrescriptionStatus.Discontinued;
                        if (c1 || c2 || c3)
                        {
                            this.Status = newStatus;
                            return true;
                        }
                        return false;
                    }
                    if (Status == PrescriptionStatus.Rejected)
                    {
                        var c1 = newStatus == PrescriptionStatus.Pending;
                        if (c1)
                        {
                            this.Status = newStatus;
                            return true;
                        }
                        return false;
                    }
                    return false;
                }*/

        public void UpdateStatus(PrescriptionStatus newStatus)
        {
            if (Status == PrescriptionStatus.Completed || Status == PrescriptionStatus.Discontinued)
                throw new UpdatePrescriptionStatusException("Can't update status of already completed of discontinued prescription");

            if (Status == PrescriptionStatus.Draft)
            {
                if (newStatus == PrescriptionStatus.Pending)
                {
                    this.Status = newStatus;
                    return;
                }
                throw new UpdatePrescriptionStatusException($"Can't update status of Draft to {newStatus}, new status must be Pending");
            }
            else if (Status == PrescriptionStatus.Pending)
            {
                var c1 = newStatus == PrescriptionStatus.Rejected;
                var c2 = newStatus == PrescriptionStatus.Active;
                var c3 = newStatus == PrescriptionStatus.Discontinued;
                if (c1 || c2 || c3)
                {
                    this.Status = newStatus;
                    return;
                }
                throw new UpdatePrescriptionStatusException($"Can't update status of {this.Status} to {newStatus}, Pending can be changed to Rejected, Active Or Discontinued only");
            }
            else if (Status == PrescriptionStatus.Rejected)
            {
                var c1 = newStatus == PrescriptionStatus.Pending;
                var c2 = newStatus == PrescriptionStatus.Discontinued;
                if (c1 || c2)
                {
                    this.Status = newStatus;
                    return;
                }
                throw new UpdatePrescriptionStatusException($"Can't update status of {this.Status} to {newStatus}, Rejected can be changed to Pending Or Discontinued only");
            }
            throw new UpdatePrescriptionStatusException($"Can't update status of {this.Status} to {newStatus}, unhandled case");
        }
    }
}