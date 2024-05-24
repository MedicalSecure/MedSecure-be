namespace Medication.Application.Dtos;


public record DrugDto(
    Guid? Id,
    string Name,
    string Dosage,
    string Form,
    string Code,
    string Unit,
    string Description, 
    DateTime ExpiredAt,
    int Stock,
    int? AvailableStock,
    int AlertStock,
    int AvrgStock,
    int MinStock,
    int SafetyStock, 
    int ReservedStock,
    decimal Price,
    bool? IsDrugExist,
    bool? IsDosageValid
    );



