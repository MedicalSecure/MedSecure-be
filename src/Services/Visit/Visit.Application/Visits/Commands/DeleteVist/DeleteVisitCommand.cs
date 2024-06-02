namespace Visit.Application.Visits.Commands.DeleteVist;
public record DeleteVisitCommand(Guid Id) : ICommand<DeleteVisitResult>;
public record DeleteVisitResult(bool IsSuccess);

public class DeleteVisitCommandValidator : AbstractValidator<DeleteVisitCommand>
{
    public DeleteVisitCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("VisitId is required ");
    }

}
