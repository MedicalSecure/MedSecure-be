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
                QuantityBE: dispense.QuantityBE,
                QuantityAE: dispense.QuantityAE
            )).ToList();
        }
        public static SimpleRegisterDto ToSimpleRegisterDto(this Register Register)
        {
            return new SimpleRegisterDto
            {
                Id = Register.Id,
              
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
    }
}
