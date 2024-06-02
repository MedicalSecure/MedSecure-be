namespace Registration.Application.Registers.Queries.GetRegistersById
{
    public record GetRegistersByIdQuery(Guid Id) : IQuery<GetRegistersByIdResult>;
    public record GetRegistersByIdResult(RegisterDto Register);
}