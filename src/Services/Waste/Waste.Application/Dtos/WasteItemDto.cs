
namespace Waste.Application.Dtos;

public record WasteItemDto(Guid Id, Guid WasteId, Guid ProductId, int Quantity, decimal Weight);
