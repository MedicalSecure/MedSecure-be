using BacPatient.Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public static Medication ToSimpleMedicineEntity(this SimpleMedicationDto Medication)
        {
           
            return new Medication(
                Id:MedicationId.Of(Guid.NewGuid()),
                Name: Medication.Name,
                Dosage: Medication.Dosage,
                Form: Medication.Form,
                Description: Medication.Description
            );
        }
        public static Prescription ToPrescriptionEntity(this SimplePrescriptionDto simplePrescription)
        { 
            var pres =  new Prescription(
                id : PrescriptionId.Of(Guid.NewGuid()) ,
                register : simplePrescription.Register.ToRegisterEntity(),
           unitCare : simplePrescription.UnitCare.ToUnitCareEntity(),
           createdAt : simplePrescription.CreatedAt
            );

            pres.addPosologies(simplePrescription.Posologies.ToPosologyEntities(PrescriptionId.Of(simplePrescription.Id)));

            return pres;
        }
        public static Room ToRoomEntity(this SimpleRoomDto simpleRoom)
        {
            return new Room(
                id : RoomId.Of(Guid.NewGuid()),
                roomNumber :   simpleRoom.RoomNumber ?? 0, 
             status :   simpleRoom.Status ?? Status.unavailable
            );
        }
        public static UnitCare ToUnitCareEntity(this SimpleUnitCareDto simpleUnitCare)
        {
            return new UnitCare (
         id: UnitCareId.Of(Guid.NewGuid()) ,
                title :   simpleUnitCare.Title ?? "", // Assuming default value of empty string if null
              description :   simpleUnitCare.Description ?? "" // Assuming default value of empty string if null
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
            var pos = new Posology(
        id : PosologyId.Of(Guid.NewGuid()) ,
             medicine :    simplePosology.Medication.ToMedicationEntity(),
            
           startDate :      simplePosology.StartDate,
             endDate :   simplePosology.EndDate,
             isPremenant :     simplePosology.IsPermanent
            );
            pos.AddComments(simplePosology.Comments.ToCommentEntities());
            pos.AddDispenses(simplePosology.Dispenses.ToDispenseEntities());
            return pos;
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
            return new  Comment (
                id : CommentId.Of(Guid.NewGuid()) ,
          label :       simpleComment.Label ?? "",
           content :    simpleComment.Content ?? ""
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
            return new Dispense(
                id: DispenseId.Of(Guid.NewGuid()),
                simpleDispense.Hour,
                simpleDispense.BeforeMeal ,
                simpleDispense.AfterMeal
                ) ;
        }
        public static Register ToRegisterEntity(this SimpleRegisterDto simpleRegister)
        {
            return  new Register(
                id : RegisterId.Of(Guid.NewGuid()) ,
             patient :   simpleRegister.Patient.ToPatientEntity() ?? throw new ArgumentNullException(nameof(simpleRegister.Patient))
            );
        }
        public static Medication ToMedicationEntity(this SimpleMedicationDto simpleMedication)
        {
            return new   Medication(

            id : MedicationId.Of(Guid.NewGuid()),
      Name :   simpleMedication.Name ?? "", 
          Form :     simpleMedication.Form ?? Route.Spray,
          Description :    simpleMedication.Description ?? "" 
            );
        }

        public static Patient ToPatientEntity(this SimplePatientDto simplePatient)
        {
            return  new Patient(
                patientid: PatientId.Of(Guid.NewGuid()),
            firstName :    simplePatient.FirstName ?? "", 
         lastName :       simplePatient.LastName ?? "",
         dateOfbirth :      simplePatient.DateOfbirth
            );
        }
    }

}
