
namespace Visit.Application.Visits.Commands.CreateVisit;
public record CreateVisitCommand (VisitDto Visit):ICommand<CreateVisitResult>;

public record CreateVisitResult(Guid Id);
public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
{
    public CreateVisitCommandValidator()
    {
      
        RuleFor(x => x.Visit.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Visit.EndDate).LessThan(x => x.Visit.StartDate).WithMessage("EndDate should be > StartDate");

    }
}
