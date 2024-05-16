namespace Prescription.Infrastructure.Database.Extensions
{
    internal class InitialData
    {
        private static readonly CommentId commentId1 = CommentId.Of(new Guid("f3c58f4e-4e49-4180-ba4c-0a2e8cddc58c"));
        private static readonly CommentId commentId2 = CommentId.Of(new Guid("2b05fc3d-2e2e-4e88-8a91-2dcf3a01c3d1"));

        private static readonly DispenseId dispenseId1 = DispenseId.Of(new Guid("7506213d-3b5f-4498-b35c-9169a600ff10"));
        private static readonly DispenseId dispenseId2 = DispenseId.Of(new Guid("0f42ff42-f701-48c9-a7b5-c56ad78f55b1"));

        private static readonly DoctorId doctorId = DoctorId.Of(new Guid("44444444-4444-4444-4444-444444444444"));
        private static readonly DoctorId doctorId2 = DoctorId.Of(new Guid("44444444-4444-4444-4444-444444444445")); // Next sequential number for doctor
        private static readonly PatientId patientId = PatientId.Of(new Guid("22222222-2222-2222-2222-222222222222"));

        private static readonly MedicationId medicationId = MedicationId.Of(new Guid("55555555-5555-5555-5555-555555555555"));
        private static readonly MedicationId medicationId2 = MedicationId.Of(new Guid("55555555-5555-5555-5555-555555555556"));

        private static readonly PosologyId posologyId = PosologyId.Of(new Guid("142f0efe-9e11-4808-a7f6-fcb564908772"));
        private static readonly PrescriptionId prescriptionId = PrescriptionId.Of(new Guid("7506213d-3b5f-4498-b35c-9169a600ff12"));

        private static readonly RegisterId registerId = RegisterId.Of(new Guid("77777777-7777-7777-7777-777777777777"));

        public static IEnumerable<Comment> Comments
        {
            get
            {
                try
                {
                    return new List<Comment>
                    {
                        Comment.Create(posologyId,"comment","Comment 1",doctorId.ToString()),
                        Comment.Create(posologyId,"caution","Comment 2",doctorId.ToString()),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Comment), ex.Message);
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
                        Dispense.Create(posologyId,4,3,5,doctorId.ToString()),
                        Dispense.Create(posologyId,5,4,8, doctorId.ToString()),
                        Dispense.Create(posologyId,6,5,9, doctorId.ToString()),
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Dispense), ex.Message);
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

        public static List<Posology> posology(List<Medication> medications)
        {
            if (medications.Count < 1) return null!;
            try
            {
                Posology posology1 = Posology.Create(prescriptionId, medications[0].Id, new DateTime(), null, true, doctorId.ToString());
                Posology posology2 = Posology.Create(prescriptionId, medications[1].Id, new DateTime(), null, true, doctorId.ToString());
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

        public static List<Symptom> Symptoms()
        {
            try
            {
                List<Symptom> result = new List<Symptom>();
                foreach (string item in symptomIndexMap.Keys)
                {
                    var symptom = Symptom.Create(symptomIndexMap[item].ToString(), item, item, item);
                    result.Add(symptom);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Posology), ex.Message);
            }
        }

        public static List<Diagnosis> DiagnosisInitialData()
        {
            try
            {
                List<Diagnosis> result = new List<Diagnosis>();
                var index = 0;
                foreach (string item in diagnosisList)
                {
                    var d = Diagnosis.Create(icdCodesList[index], item, shortDescriptionsList[index], longDescriptionsList[index]);
                    result.Add(d);
                    index++;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Diagnosis), ex.Message);
            }
        }

        public static Domain.Entities.Prescription Prescription(List<Medication> medications, List<Symptom> symptoms, List<Diagnosis> diagnosis)
        {
            try
            {
                var p = Domain.Entities.Prescription.Create(registerId, doctorId);
                p.addPosology(posology(medications)[0]);
                p.addPosology(posology(medications)[1]);

                p.addSymptom(symptoms[0]);
                p.addSymptom(symptoms[1]);
                p.addDiagnosis(diagnosis[0]);
                p.addDiagnosis(diagnosis[8]);
                p.addDiagnosis(diagnosis[2]);
                return p;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Domain.Entities.Prescription), ex.Message);
            }
        }

        //private static List<string> symptomColumns = new List<string> { "itching", "skin_rash", "nodal_skin_eruptions", "continuous_sneezing", "shivering", "chills", "joint_pain", "stomach_pain", "acidity", "ulcers_on_tongue", "muscle_wasting", "vomiting", "burning_micturition", "spotting_ urination", "fatigue", "weight_gain", "anxiety", "cold_hands_and_feets", "mood_swings", "weight_loss", "restlessness", "lethargy", "patches_in_throat", "irregular_sugar_level", "cough", "high_fever", "sunken_eyes", "breathlessness", "sweating", "dehydration", "indigestion", "headache", "yellowish_skin", "dark_urine", "nausea", "loss_of_appetite", "pain_behind_the_eyes", "back_pain", "constipation", "abdominal_pain", "diarrhoea", "mild_fever", "yellow_urine", "yellowing_of_eyes", "acute_liver_failure", "fluid_overload", "swelling_of_stomach", "swelled_lymph_nodes", "malaise", "blurred_and_distorted_vision", "phlegm", "throat_irritation", "redness_of_eyes", "sinus_pressure", "runny_nose", "congestion", "chest_pain", "weakness_in_limbs", "fast_heart_rate", "pain_during_bowel_movements", "pain_in_anal_region", "bloody_stool", "irritation_in_anus", "neck_pain", "dizziness", "cramps", "bruising", "obesity", "swollen_legs", "swollen_blood_vessels", "puffy_face_and_eyes", "enlarged_thyroid", "brittle_nails", "swollen_extremeties", "excessive_hunger", "extra_marital_contacts", "drying_and_tingling_lips", "slurred_speech", "knee_pain", "hip_joint_pain", "muscle_weakness", "stiff_neck", "swelling_joints", "movement_stiffness", "spinning_movements", "loss_of_balance", "unsteadiness", "weakness_of_one_body_side", "loss_of_smell", "bladder_discomfort", "foul_smell_of urine", "continuous_feel_of_urine", "passage_of_gases", "internal_itching", "toxic_look_(typhos)", "depression", "irritability", "muscle_pain", "altered_sensorium", "red_spots_over_body", "belly_pain", "abnormal_menstruation", "dischromic _patches", "watering_from_eyes", "increased_appetite", "polyuria", "family_history", "mucoid_sputum", "rusty_sputum", "lack_of_concentration", "visual_disturbances", "receiving_blood_transfusion", "receiving_unsterile_injections", "coma", "stomach_bleeding", "distention_of_abdomen", "history_of_alcohol_consumption", "fluid_overload", "blood_in_sputum", "prominent_veins_on_calf", "palpitations", "painful_walking", "pus_filled_pimples", "blackheads", "scurring", "skin_peeling", "silver_like_dusting", "small_dents_in_nails", "inflammatory_nails", "blister", "red_sore_around_nose", "yellow_crust_ooze" };

        private static Dictionary<string, int> symptomIndexMap = new Dictionary<string, int>
        {
            {"Itching", 0},
            {"Skin rash", 1},
            {"Nodal skin eruptions", 2},
            {"Continuous sneezing", 3},
            {"Shivering", 4},
            {"Chills", 5},
            {"Joint pain", 6},
            {"Stomach pain", 7},
            {"Acidity", 8},
            {"Ulcers on tongue", 9},
            {"Muscle wasting", 10},
            {"Vomiting", 11},
            {"Burning micturition", 12},
            {"Spotting urination", 13},
            {"Fatigue", 14},
            {"Weight gain", 15},
            {"Anxiety", 16},
            {"Cold hands and feets", 17},
            {"Mood swings", 18},
            {"Weight loss", 19},
            {"Restlessness", 20},
            {"Lethargy", 21},
            {"Patches in throat", 22},
            {"Irregular sugar level", 23},
            {"Cough", 24},
            {"High fever", 25},
            {"Sunken eyes", 26},
            {"Breathlessness", 27},
            {"Sweating", 28},
            {"Dehydration", 29},
            {"Indigestion", 30},
            {"Headache", 31},
            {"Yellowish skin", 32},
            {"Dark urine", 33},
            {"Nausea", 34},
            {"Loss of appetite", 35},
            {"Pain behind the eyes", 36},
            {"Back pain", 37},
            {"Constipation", 38},
            {"Abdominal pain", 39},
            {"Diarrhoea", 40},
            {"Mild fever", 41},
            {"Yellow urine", 42},
            {"Yellowing of eyes", 43},
            {"Acute liver failure", 44},
            {"Fluid overload", 45},
            {"Swelling of stomach", 46},
            {"Swelled lymph nodes", 47},
            {"Malaise", 48},
            {"Blurred and distorted vision", 49},
            {"Phlegm", 50},
            {"Throat irritation", 51},
            {"Redness of eyes", 52},
            {"Sinus pressure", 53},
            {"Runny nose", 54},
            {"Congestion", 55},
            {"Chest pain", 56},
            {"Weakness in limbs", 57},
            {"Fast heart rate", 58},
            {"Pain during bowel movements", 59},
            {"Pain in anal region", 60},
            {"Bloody stool", 61},
            {"Irritation in anus", 62},
            {"Neck pain", 63},
            {"Dizziness", 64},
            {"Cramps", 65},
            {"Bruising", 66},
            {"Obesity", 67},
            {"Swollen legs", 68},
            {"Swollen blood vessels", 69},
            {"Puffy face and eyes", 70},
            {"Enlarged thyroid", 71},
            {"Brittle nails", 72},
            {"Swollen extremeties", 73},
            {"Excessive hunger", 74},
            {"Extra marital contacts", 75},
            {"Drying and tingling lips", 76},
            {"Slurred speech", 77},
            {"Knee pain", 78},
            {"Hip joint pain", 79},
            {"Muscle weakness", 80},
            {"Stiff neck", 81},
            {"Swelling joints", 82},
            {"Movement stiffness", 83},
            {"Spinning movements", 84},
            {"Loss of balance", 85},
            {"Unsteadiness", 86},
            {"Weakness of one body side", 87},
            {"Loss of smell", 88},
            {"Bladder discomfort", 89},
            {"Foul smell of urine", 90},
            {"Continuous feel of urine", 91},
            {"Passage of gases", 92},
            {"Internal itching", 93},
            {"Toxic look (typhos)", 94},
            {"Depression", 95},
            {"Irritability", 96},
            {"Muscle pain", 97},
            {"Altered sensorium", 98},
            {"Red spots over body", 99},
            {"Belly pain", 100},
            {"Abnormal menstruation", 101},
            {"Dischromic patches", 102},
            {"Watering from eyes", 103},
            {"Increased appetite", 104},
            {"Polyuria", 105},
            {"Family history", 106},
            {"Mucoid sputum", 107},
            {"Rusty sputum", 108},
            {"Lack of concentration", 109},
            {"Visual disturbances", 110},
            {"Receiving blood transfusion", 111},
            {"Receiving unsterile injections", 112},
            {"Coma", 113},
            {"Stomach bleeding", 114},
            {"Distention of abdomen", 115},
            {"History of alcohol consumption", 116},
            {"Fluid Overload", 117},
            {"Blood in sputum", 118},
            {"Prominent veins on calf", 119},
            {"Palpitations", 120},
            {"Painful walking", 121},
            {"Pus filled pimples", 122},
            {"Blackheads", 123},
            {"Scurring", 124},
            {"Skin peeling", 125},
            {"Silver like dusting", 126},
            {"Small dents in nails", 127},
            {"Inflammatory nails", 128},
            {"Blister", 129},
            {"Red sore around nose", 130},
            {"Yellow crust ooze", 131}
        };

        private static List<string> diagnosisList = new List<string>() { "Hepatitis B", "Typhoid", "Dengue", "Tuberculosis", "Chicken pox", "Peptic ulcer diseae", "Allergy", "Osteoarthristis", "Hyperthyroidism", "Paralysis (brain hemorrhage)", "Impetigo", "Hypothyroidism", "AIDS", "Hepatitis E", "Diabetes ", "Acne", "Hepatitis C", "Migraine", "Common Cold", "Hypertension ", "Fungal infection", "Alcoholic hepatitis", "prognosis", "Cervical spondylosis", "GERD", "Hepatitis D", "Bronchial Asthma", "Heart attack", "Hypoglycemia", "Psoriasis", "Jaundice", "Chronic cholestasis", "Drug Reaction", "hepatitis A", "Urinary tract infection", "Pneumonia", "Malaria", "Arthritis", "(vertigo) Paroymsal  Positional Vertigo", "Varicose veins", "Dimorphic hemmorhoids(piles)", "Gastroenteritis" };

        private static List<string> shortDescriptionsList = new List<string>()
        {
            "Viral infection affecting the liver",
            "Bacterial infection from contaminated food/water",
            "Mosquito-borne viral disease with high fever",
            "Infectious bacterial disease affecting the lungs",
            "Highly contagious viral disease causing rash",
            "Painful sores or erosions in the stomach lining",
            "Immune system's overreaction to harmless substance",
            "Degenerative joint disease causing cartilage wear",
            "Overproduction of thyroid hormones",
            "Brain hemorrhage leading to paralysis",
            "Contagious bacterial skin infection",
            "Underproduction of thyroid hormones",
            "Acquired immunodeficiency syndrome",
            "Viral infection affecting the liver",
            "Chronic metabolic disorder affecting blood sugar",
            "Skin condition causing pimples and blackheads",
            "Viral infection affecting the liver",
            "Severe recurring headaches",
            "Viral infection causing respiratory symptoms",
            "High blood pressure condition",
            "Infection caused by fungus",
            "Liver inflammation due to alcohol consumption",
            "Predicting the likely course of a medical condition",
            "Neck pain and stiffness due to spinal degeneration",
            "Chronic acid reflux disease",
            "Viral infection affecting the liver",
            "Chronic inflammatory lung disease",
            "Blockage of blood flow to the heart muscle",
            "Low blood sugar levels",
            "Autoimmune skin condition causing red, scaly patches",
            "Yellowing of skin and whites of the eyes",
            "Chronic liver disease causing bile duct blockage",
            "Adverse reaction to medication",
            "Viral infection affecting the liver",
            "Infection of the urinary tract",
            "Lung infection caused by bacteria or viruses",
            "Mosquito-borne infectious disease",
            "Inflammation of joints causing pain and stiffness",
            "Vertigo caused by inner ear disorder",
            "Twisted, enlarged veins in the legs",
            "Swollen and inflamed veins in the rectum",
            "Inflammation of the stomach and intestines"
        };

        private static List<string> icdCodesList = new List<string>()
        {
            "B18.1",
            "A01.0",
            "A90",
            "A15.0",
            "B01.0",
            "K27",
            "T78.4",
            "M19.9",
            "E05.9",
            "I61.9",
            "L01.0",
            "E03.9",
            "B24",
            "B17.2",
            "E11.9",
            "L70.0",
            "B17.1",
            "G43.9",
            "J00",
            "I10",
            "B49",
            "K70.1",
            "-",
            "M47.8",
            "K21.9",
            "B17.0",
            "J45.9",
            "I21.9",
            "E16.2",
            "L40.0",
            "R17",
            "K74.3",
            "T88.7",
            "B15.9",
            "N39.0",
            "J15.9",
            "B54",
            "M19.9",
            "H81.1",
            "I83.9",
            "I84.8",
            "K52.9"
        };

        private static List<string> longDescriptionsList = new List<string>()
        {
            "A viral infection that attacks the liver and can cause severe liver damage and complications",
            "A bacterial infection caused by ingestion of food or water contaminated with Salmonella typhi bacteria",
            "A mosquito-borne viral disease that causes a severe flu-like illness with high fever, rash, and muscle/joint pain",
            "An infectious bacterial disease that primarily affects the lungs and can spread through coughing and sneezing",
            "A highly contagious viral disease that causes an itchy, blister-like rash, typically in children",
            "A condition characterized by painful sores or erosions in the lining of the stomach or duodenum",
            "An overreaction of the immune system to a harmless substance, causing symptoms like sneezing, rashes, or swelling",
            "A degenerative joint disease that causes the cartilage between bones to wear away, leading to pain and stiffness",
            "A condition caused by overproduction of thyroid hormones, leading to a rapid or irregular heartbeat, weight loss, and nervousness",
            "A condition caused by bleeding within the brain tissue, which can lead to paralysis or other neurological impairments",
            "A highly contagious bacterial skin infection that causes red sores and can lead to scarring if untreated",
            "A condition caused by underproduction of thyroid hormones, leading to fatigue, weight gain, and sensitivity to cold",
            "An acquired immunodeficiency syndrome caused by the human immunodeficiency virus (HIV), which attacks the body's immune system",
            "A viral infection that attacks the liver and can cause jaundice, abdominal pain, and potentially severe liver damage",
            "A chronic metabolic disorder characterized by high blood sugar levels due to the body's inability to produce or use insulin effectively",
            "A common skin condition that occurs when hair follicles become clogged with dead skin cells and oil, causing pimples and blackheads",
            "A viral infection that attacks the liver and can lead to chronic liver disease, cirrhosis, and liver cancer if left untreated",
            "A severe, recurring headache that can cause throbbing pain, nausea, and sensitivity to light and sound",
            "A viral infection of the upper respiratory tract that causes symptoms such as runny nose, sore throat, and coughing",
            "A condition in which the force of blood against artery walls is consistently too high, increasing the risk of heart disease and stroke",
            "An infection caused by a fungus, which can affect the skin, nails, or internal organs, depending on the type of fungus",
            "Inflammation of the liver caused by excessive alcohol consumption, which can lead to cirrhosis and liver failure",
            "The process of determining the likely course and outcome of a medical condition based on various factors",
            "A condition caused by degeneration of the cervical vertebrae in the neck, leading to pain, stiffness, and potentially nerve compression",
            "A chronic condition in which stomach acid flows back into the esophagus, causing heartburn and potential damage to the esophageal lining",
            "A viral infection that attacks the liver and can cause severe liver damage, particularly in those with pre-existing liver disease",
            "A chronic inflammatory lung disease that causes airway obstruction, wheezing, and shortness of breath due to bronchial tube inflammation",
            "A condition caused by a blockage of blood flow to the heart muscle, leading to heart muscle damage or death",
            "A condition characterized by abnormally low levels of glucose (sugar) in the blood, which can cause symptoms like shakiness, sweating, and confusion",
            "An autoimmune skin condition that causes red, scaly patches due to the body's immune system attacking healthy skin cells",
            "A condition characterized by yellowing of the skin and whites of the eyes, often due to a buildup of bilirubin from liver or gallbladder disorders",
            "A chronic liver disease that causes blockage of the bile ducts, leading to a buildup of bile and potential liver damage",
            "An adverse reaction to a medication, which can range from mild side effects to severe, life-threatening complications",
            "A viral infection that attacks the liver and can cause mild to severe illness, including fever, fatigue, and jaundice",
            "An infection that affects the urinary tract, including the bladder, kidneys, and urethra, often caused by bacteria",
            "An infection of the lungs that can be caused by various bacteria or viruses, leading to coughing, fever, and difficulty breathing",
            "A mosquito-borne infectious disease that causes symptoms like fever, chills, and flu-like illness, and can sometimes lead to severe complications",
            "A condition characterized by inflammation of one or more joints, causing pain, swelling, and stiffness, often resulting from wear and tear or autoimmune disorders",
            "A type of vertigo caused by a disorder in the inner ear, leading to sudden episodes of spinning or whirling sensations",
            "A condition characterized by twisted, enlarged veins in the legs, often caused by increased pressure and weakened vein walls",
            "A condition characterized by swollen and inflamed veins in the rectum, which can cause pain, bleeding, and itching",
            "Inflammation of the stomach and intestines, often caused by viruses, bacteria, or other factors, leading to diarrhea, vomiting, and abdominal pain"
        };
    }
}