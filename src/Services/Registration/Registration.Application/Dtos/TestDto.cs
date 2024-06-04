namespace Registration.Application.Dtos
{
    public record TestDto(Guid? Id, string Code, string Description, Language Language, TestType TestType, Guid? RegisterId);
}