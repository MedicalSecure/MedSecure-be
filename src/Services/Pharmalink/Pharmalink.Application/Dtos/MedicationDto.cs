namespace Pharmalink.Application.Dtos;

public record MedicationDto(
    Guid Id,
    string Name,
    string Dosage,
    string Form,
    string Code,
    string Unit,
    string Description, 
    DateTime ExpiredAt,
    int Stock,
    int AlertStock,
    int AvrgStock,
    int MinStock,
    int SafetyStock, 
    int ReservedStock,
    decimal Price
    );



