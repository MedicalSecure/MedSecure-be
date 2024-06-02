namespace Registration.Application.Registers.Commands.ArchiveUnarchiveRegister
{
    public record ArchiveUnarchiveRegisterCommand(Guid registerId, RegisterStatus registerStatus) : ICommand<ArchiveUnarchiveRegisterResult>;
    public record ArchiveUnarchiveRegisterResult(string registerId);

    public class ArchiveUnarchiveRegisterCommandValidator : AbstractValidator<ArchiveUnarchiveRegisterCommand>
    {
        public ArchiveUnarchiveRegisterCommandValidator()
        {
            RuleFor(x => x.registerId).NotEmpty().WithMessage("RegisterId is required");
        }
    }
}