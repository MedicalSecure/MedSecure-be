using Registration.Domain.Models;

namespace Registration.Application.Dtos
{
    public record RiskFactorDto(Guid Id, string key, string value,string code,string description,Boolean isSelected,string type,string icon);
    
}
