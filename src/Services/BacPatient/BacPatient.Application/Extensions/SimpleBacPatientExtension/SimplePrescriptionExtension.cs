using BacPatient.Domain.Models;
using System.Reflection.Emit;

namespace BacPatient.Application.Extensions.SimpleBacPatientExtension
{
    public static class SimplePrescriptionExtension
    {
        public static SimplePrescriptionDto ToSimplePrescriptionDto(this Prescription Prescription)
        {
            var x = new SimplePrescriptionDto(
                Id: Prescription.Id.Value,
                Register: Prescription.Register.ToSimpleRegisterDto() ,
                CreatedAt : Prescription.CreatedAt , 
                Posologies : Prescription.Posology.ToSimplePosologyDto(),
                UnitCare : Prescription.UnitCare.ToSimpleUnitCareDto()
            );
            return x;
        }
   
     
        public static SimpleRoomDto ToSimpleRoomDto(this Room Room)
        {
            var x = new SimpleRoomDto(
                Id: Room.Id.Value,
                RoomNumber: Room.RoomNumber,
                Status: Room.Status
            );
            return x;
        }
        public static SimpleUnitCareDto ToSimpleUnitCareDto(this UnitCare unitCare)
        {
            var x = new SimpleUnitCareDto(
                Id: unitCare.Id.Value,
                Title: unitCare.Title,
                Description: unitCare.Description
            );
            return x;
        }
        public static ICollection<SimplePosologyDto> ToSimplePosologyDto(this IEnumerable<Posology> Posologies)
        {
            return Posologies.Select(pos => new SimplePosologyDto(
                Id: pos.Id.Value,
                PrescriptionId: pos.PrescriptionId.Value,
                Medication: pos.Medication.ToSimpleMedicationDto(),
                StartDate: pos.StartDate,
                EndDate: pos.EndDate,
                IsPermanent: pos.IsPermanent,
                Comments: pos.Comments.ToSimpleCommentDto(),
                Dispenses: pos.Dispenses.ToSimpleDispensesDto()
            )).ToList(); 
        }
        public static ICollection<SimpleCommentsDto> ToSimpleCommentDto(this IEnumerable<Comment> Comments)
        {
            return Comments.Select(comment => new SimpleCommentsDto(
                Id: comment.Id.Value,
                PosologyId: comment.PosologyId.Value,
                Label: comment.Label,
                Content: comment.Content
            )).ToList();
        }
        public static ICollection<SimpleDispensesDto> ToSimpleDispensesDto(this IEnumerable<Dispense> Dispenses)
        {
            return Dispenses.Select(dispense => new SimpleDispensesDto(
                Id: dispense.Id.Value,
                PosologyId: dispense.PosologyId.Value,
                Hour: dispense.Hour,
                BeforeMeal : dispense.BeforeMeal ,
                AfterMeal : dispense.AfterMeal

              
            )).ToList();
        }
        public static SimpleRegisterDto ToSimpleRegisterDto(this Register Register)
        {
            return new SimpleRegisterDto
            {
                Id = Register.Id.Value,
              
                Patient = Register.Patient.ToSimplePatientDto(),
                   };
        }
        public static SimpleMedicationDto ToSimpleMedicationDto(this Medication Medication)
        {
           
            return new SimpleMedicationDto(
                Id: Medication.Id.Value,
                Name: Medication.Name,
                Dosage: Medication.Dosage,
                Form: Medication.Form,
                Description: Medication.Description
            );
        }
        public static Medication ToSimpleMedicineEntity(this SimpleMedicationDto Medication)
        {
           
            return new Medication(
                Id:MedicationId.Of(Medication.Id),
                Name: Medication.Name,
                Dosage: Medication.Dosage,
                Form: Medication.Form,
                Description: Medication.Description
            );
        }
        public static SimplePatientDto ToSimplePatientDto(this Patient patient)
        {
            return new SimplePatientDto(
                Id: patient.Id.Value,
                FirstName: patient.FirstName,
                LastName: patient.LastName,
                DateOfbirth: patient.DateOfBirth,
                Gender: patient.Gender
            );
        }
        public static Prescription ToPrescriptionEntity(this SimplePrescriptionDto simplePrescription)
        {
            return Prescription.Create(

                simplePrescription.Register.ToRegisterEntity(),
                simplePrescription.UnitCare.ToUnitCareEntity(),
               
                simplePrescription.CreatedAt
            );
        }

        public static Room ToRoomEntity(this SimpleRoomDto simpleRoom)
        {
            return Room.Create(
                simpleRoom.RoomNumber ?? 0, // Assuming default value of 0 if null
                simpleRoom.Status ?? Status.unavailable // Assuming default value of Unknown if null
            );
        }

        public static UnitCare ToUnitCareEntity(this SimpleUnitCareDto simpleUnitCare)
        {
            return UnitCare.Create(
                simpleUnitCare.Title ?? "", // Assuming default value of empty string if null
                simpleUnitCare.Description ?? "" // Assuming default value of empty string if null
            );
        }

        public static ICollection<Posology> ToPosologyEntities(this IEnumerable<SimplePosologyDto> simplePosologies, PrescriptionId prescriptionId)
        {
            var posologies = new List<Posology>();
            foreach (var simplePosology in simplePosologies)
            {
                posologies.Add(simplePosology.ToPosologyEntity(prescriptionId));
            }
            return posologies;
        }

        public static Posology ToPosologyEntity(this SimplePosologyDto simplePosology, PrescriptionId prescriptionId)
        {
            return Posology.Create(
                prescriptionId,
                simplePosology.Medication.ToMedicationEntity(),
            
                simplePosology.StartDate,
                simplePosology.EndDate,
                simplePosology.IsPermanent
            );
        }

        public static ICollection<Comment> ToCommentEntities(this IEnumerable<SimpleCommentsDto> simpleComments)
        {
            var comments = new List<Comment>();
            foreach (var simpleComment in simpleComments)
            {
                comments.Add(simpleComment.ToCommentEntity());
            }
            return comments;
        }

        public static Comment ToCommentEntity(this SimpleCommentsDto simpleComment)
        {
            return Comment.Create(
                PosologyId.Of(simpleComment.PosologyId),
                simpleComment.Label ?? "",
              simpleComment.Content ?? ""
                ) ;
            
                
           
        }

        public static ICollection<Dispense> ToDispenseEntities(this IEnumerable<SimpleDispensesDto> simpleDispenses)
        {
            var dispenses = new List<Dispense>();
            foreach (var simpleDispense in simpleDispenses)
            {
                dispenses.Add(simpleDispense.ToDispenseEntity());
            }
            return dispenses;
        }

        public static Dispense ToDispenseEntity(this SimpleDispensesDto simpleDispense)
        {
            return  Dispense.Create(
            
                PosologyId.Of(simpleDispense.PosologyId),
                simpleDispense.Hour,
          simpleDispense.BeforeMeal,
                simpleDispense.AfterMeal
            );
        }

        public static Register ToRegisterEntity(this SimpleRegisterDto simpleRegister)
        {
            return Register.Create(
               simpleRegister.Patient.ToPatientEntity() ?? throw new ArgumentNullException(nameof(simpleRegister.Patient))
            );
        }

        public static Medication ToMedicationEntity(this SimpleMedicationDto simpleMedication)
        {
            return  Medication.Create(
            
               simpleMedication.Name ?? "", 
               simpleMedication.Form ?? Route.Spray,
              simpleMedication.Description ?? "" 
            );
        }

        public static Patient ToPatientEntity(this SimplePatientDto simplePatient)
        {
            return  Patient.Create(
                simplePatient.FirstName ?? "", 
                simplePatient.LastName ?? "",
               simplePatient.DateOfbirth
            );
        }
    }

}
