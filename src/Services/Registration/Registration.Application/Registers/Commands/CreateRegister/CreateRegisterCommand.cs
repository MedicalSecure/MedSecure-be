namespace Registration.Application.Registers.Commands.CreateRegister
{
    public record CreateRegisterCommand(RegisterDto Register) : ICommand<CreateRegisterResult>;
    public record CreateRegisterResult(Guid Id);
    public class CreateRegisterValidatior : AbstractValidator<CreateRegisterCommand>
    {
        public CreateRegisterValidatior()
        {
            //RuleFor(x => x.Register.personalHistory).NotEmpty();
        }
    }
}
