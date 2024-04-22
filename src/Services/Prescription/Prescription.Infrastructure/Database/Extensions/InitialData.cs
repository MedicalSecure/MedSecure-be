using Prescription.Domain.Entities;
using Prescription.Domain.Exceptions;

namespace Prescription.Infrastructure.Database.Extensions
{
    internal class InitialData
    {
        private static readonly Guid commentId1 = new Guid("f3c58f4e-4e49-4180-ba4c-0a2e8cddc58c");
        private static readonly Guid commentId2 = new Guid("2b05fc3d-2e2e-4e88-8a91-2dcf3a01c3d1");

        private static readonly Guid dispenseId1 = new Guid("7506213d-3b5f-4498-b35c-9169a600ff10");
        private static readonly Guid dispenseId2 = new Guid("0f42ff42-f701-48c9-a7b5-c56ad78f55b1");

        private static readonly Guid doctorId = new Guid("44444444-4444-4444-4444-444444444444");
        private static readonly Guid doctorId2 = new Guid("44444444-4444-4444-4444-444444444445"); // Next sequential number for doctor
        private static readonly Guid patientId = new Guid("22222222-2222-2222-2222-222222222222");
        private static readonly Guid patientId2 = new Guid("22222222-2222-2222-2222-222222222223"); // Next sequential number for patient
        private static readonly Guid medicationId = new Guid("55555555-5555-5555-5555-555555555555");
        private static readonly Guid medicationId2 = new Guid("55555555-5555-5555-5555-555555555556");

        private static readonly Guid posologyId = new Guid("142f0efe-9e11-4808-a7f6-fcb564908772");
        private static readonly Guid prescriptionId = new Guid("7506213d-3b5f-4498-b35c-9169a600ff12");

        public static IEnumerable<Comment> Comments
        {
            get
            {
                try
                {
                    return new List<Comment>
                    {
                        Comment.Create(posologyId,"comment","Comment 1"),
                        Comment.Create(posologyId,"caution","Comment 2"),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
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
                        Dispense.Create(posologyId,4,3,5),
                        Dispense.Create(posologyId,5,4,8),
                        Dispense.Create(posologyId,6,5,9),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Dispense), ex.Message);
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
                        Doctor.Create(
                            id: doctorId,
                            firstName: "John",
                            lastName: "Doe",
                            speciality: "Cardiology",
                            dateOfBirth: new DateTime(1975, 10, 25)
                        ),
                        Doctor.Create(
                            id: doctorId2,
                            firstName: "Jane",
                            lastName: "Smith",
                            speciality: "Pediatrics",
                            dateOfBirth: new DateTime(1980, 7, 15)
                        )
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Doctor), ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves a collection of medications with their details.
        /// </summary>
        public static List<Medication> Medications
        {
            get
            {
                try
                {
                    // Create a list to hold the medications
                    var medications = new List<Medication>
                    {
                        // Create medication instances
                        Medication.Create(
                            id: medicationId,
                            name: "Aspirin",
                            dosage: "500mg",
                            form: "Tablet",
                            code: "A1010",
                            unit: "mg",
                            description: "Pain reliever and anti-inflammatory medication.",
                            expiredAt: DateTime.Now.AddYears(2),
                            stock: 20,
                            alertStock: 18,
                            avrgStock: 13,
                            minStock: 8,
                            safetyStock: 4,
                            reservedStock: 2,
                            price: 5.99m
                        ),Medication.Create(
                            id: medicationId2,
                            name: "Ibuprofen",
                            dosage: "400mg",
                            form: "Tablet",
                            code: "A2020",
                            unit: "mg",
                            description: "Nonsteroidal anti-inflammatory drug (NSAID).",
                            expiredAt: DateTime.Now.AddYears(3),
                            stock: 20,
                            alertStock: 15,
                            avrgStock: 10,
                            minStock: 7,
                            safetyStock: 3,
                            reservedStock: 1,
                            price: 6.99m
                        )
                    };

                    // Return the list of medications
                    return medications;
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Medication), ex.Message);
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
                        Patient.Create(
                            id: patientId,
                            patientName: "Patient 1",
                            dateOfbirth: new DateTime(1990, 5, 15),
                            gender: Domain.Enums.Gender.Male,
                            height: 175,
                            weight: 70,
                            register: new Register
                            {
                                familymedicalhistory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Heart Disease", value = "Yes", subRiskfactory = null },
                                    new RiskFactor { key = "Diabetes", value = "No", subRiskfactory = null }
                                },
                                personalMedicalHistory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Allergies", value = "Pollen", subRiskfactory = null },
                                    new RiskFactor { key = "Asthma", value = "No", subRiskfactory = null }
                                }
                            },
                            riskFactor: new RiskFactor
                            {
                                key = "High Blood Pressure",
                                value = "Yes",
                                subRiskfactory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Medication", value = "Yes", subRiskfactory = null }
                                }
                            },
                            disease: new RiskFactor
                            {
                                key = "Type 2 Diabetes",
                                value = "No",
                                subRiskfactory = null
                            }
                        ),
                        Patient.Create(
                            id: patientId2,
                            patientName: "Patient 2",
                            dateOfbirth: new DateTime(1985, 8, 20),
                            gender: Domain.Enums.Gender.Female,
                            height: 160,
                            weight: 60,
                            register: new Register
                            {
                                familymedicalhistory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Heart Disease", value = "No", subRiskfactory = null },
                                    new RiskFactor { key = "Diabetes", value = "Yes", subRiskfactory = null }
                                },
                                personalMedicalHistory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Allergies", value = "None", subRiskfactory = null },
                                    new RiskFactor { key = "Asthma", value = "Yes", subRiskfactory = null }
                                }
                            },
                            riskFactor: new RiskFactor
                            {
                                key = "High Cholesterol",
                                value = "Yes",
                                subRiskfactory = new List<RiskFactor>
                                {
                                    new RiskFactor { key = "Medication", value = "No", subRiskfactory = null }
                                }
                            },
                            disease: new RiskFactor
                            {
                                key = "Type 1 Diabetes",
                                value = "Yes",
                                subRiskfactory = null
                            }
                        )
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Patient), ex.Message);
                }
            }
        }

        public static List<Posology> posology(List<Medication> medications)
        {
            if (medications.Count < 1) return null!;
            try
            {
                Posology posology1 = Posology.Create(prescriptionId, medications[0], new DateTime(), null, true);
                Posology posology2 = Posology.Create(prescriptionId, medications[1], new DateTime(), null, true);
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

        public static PrescriptionEntity Prescription(Patient patient, Doctor d, List<Medication> medications)
        {
            try
            {
                var p = PrescriptionEntity.Create(patient, d);
                p.addPosology(posology(medications)[0]);
                p.addPosology(posology(medications)[1]);
                p.addSymptom(Symptom.Create("R292", "Abnormal reflex", "Abnormal reflex", "Other symptoms and signs involving the nervous and musculoskeletal systems"));
                p.addSymptom(Symptom.Create("R402", "Coma", "Unspecified coma", "Unspecified coma"));
                p.addSymptom(Symptom.Create("R1911", "Abnormal bowel sounds", "Other abnormal bowel sounds", "Other abnormal bowel sounds"));
                p.addDiagnosis(Diagnosis.Create("A000", "Cholera", "Cholera due to Vibrio cholerae 01, biovar cholerae", "Cholera due to Vibrio cholerae 01, biovar cholerae long description test"));
                p.addDiagnosis(Diagnosis.Create("D701", "Neutropenia", "Agranulocytosis secondary to cancer chemotherapy", "Agranulocytosis secondary to cancer chemotherapy long description test"));
                p.addDiagnosis(Diagnosis.Create("D511", "Vitamin B12 deficiency anemia", "Vit B12 defic anemia d/t slctv vit B12 malabsorp w protein", "Vitamin B12 deficiency anemia due to selective vitamin B12 malabsorption with proteinuria"));
                return p;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(PrescriptionEntity), ex.Message);
            }
        }
    }
}