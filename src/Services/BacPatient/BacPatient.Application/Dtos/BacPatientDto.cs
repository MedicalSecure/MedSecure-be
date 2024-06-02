

namespace BacPatient.Application.Dtos;

public record BacPatientDto(
    Guid Id,
    SimplePrescriptionDto Prescription ,  
    
    Guid NurseId,
    int Served , 
    int ToServe ,
    StatusBP Status 
   
    );
