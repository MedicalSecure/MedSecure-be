using Prescription.Domain.Entities;
using Prescription.Domain.Exceptions;

namespace Prescription.Infrastructure.Database.Extensions
{
    internal class InitialData
    {
        private static readonly string prescriptionId = "7506213d-3b5f-4498-b35c-9169a600ff12";

        private static readonly string dispenseId1 = "7506213d-3b5f-4498-b35c-9169a600ff10";
        private static readonly string dispenseId2 = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";

        private static readonly string commentId1 = "f3c58f4e-4e49-4180-ba4c-0a2e8cddc58c";
        private static readonly string commentId2 = "2b05fc3d-2e2e-4e88-8a91-2dcf3a01c3d1";

        private static readonly string medicationId = "bb63acb6-3aaf-433d-9784-e5e9a6ad6b06";
        private static readonly string posologyId = "142f0efe-9e11-4808-a7f6-fcb564908772";

        private static readonly string doctorId = "05d3a746-fb2c-4d7a-9861-103d9e112637";
        private static readonly string patientId = "ce0e148b-9906-45a1-b037-b46ea99ca85a";

        public static Medication medication1 = Medication.Create("test medication1 description");
        public static Medication medication2 = Medication.Create("test medication2 description");

        public static PrescriptionEntity prescription
        {
            get
            {
                try
                {
                    var p = PrescriptionEntity.Create(Patients.ToList()[0], Doctors.ToList()[0]);
                    p.addPosology(posology.ToList()[0]);
                    p.addPosology(posology.ToList()[1]);
                    p.addSymtom(Symptom.Create("headache", "test"));
                    p.addDiagnosis(Diagnosis.Create("Corona", "test diagnosis description"));
                    return p;
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(PrescriptionEntity), ex.Message);
                }
            }
        }

        public static IEnumerable<Patient> Patients
        {
            get
            {
                try
                {
                    return new List<Patient>
                    {
                        Patient.Create("Patient 1"),
                        Patient.Create("Patient 2"),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        public static IEnumerable<Comment> Comments
        {
            get
            {
                try
                {
                    return new List<Comment>
                    {
                        Comment.Create(Guid.Parse(posologyId),"comment","Comment 1"),
                        Comment.Create(Guid.Parse(posologyId),"caution","Comment 2"),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        public static IEnumerable<Doctor> Doctors
        {
            get
            {
                try
                {
                    return new List<Doctor>
                    {
                        Doctor.Create("Doctor 1"),
                        Doctor.Create("Doctor 2"),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Doctor), ex.Message);
                }
            }
        }

        public static IEnumerable<Dispense> Dispenses
        {
            get
            {
                try
                {
                    return new List<Dispense>
                    {
                        Dispense.Create(Guid.Parse(posologyId),4,3,5),
                        Dispense.Create(Guid.Parse(posologyId),5,4,8),
                        Dispense.Create(Guid.Parse(posologyId),6,5,9),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Dispense), ex.Message);
                }
            }
        }

        public static IEnumerable<Posology> posology
        {
            get
            {
                try
                {
                    Posology posology1 = Posology.Create(Guid.Parse(prescriptionId), medication1, new DateTime(), null, true);
                    Posology posology2 = Posology.Create(Guid.Parse(prescriptionId), medication2, new DateTime(), null, true);
                    posology1.AddDispense(Dispenses.ToArray()[0]);
                    posology1.AddDispense(Dispenses.ToArray()[1]);
                    posology2.AddDispense(Dispenses.ToArray()[2]);

                    return new List<Posology>
                    {
                        posology1,
                        posology2
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Posology), ex.Message);
                }
            }
        }
    }
}