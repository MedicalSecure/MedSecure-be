
namespace Visit.Application.Visits.Commands.UpdateVisit;

public record UpdateVisitCommand(VisitDto Visit) : ICommand<UpdateVisitResult>;

public record UpdateVisitResult(bool IsSuccess);

public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
{
    public UpdateVisitCommandValidator()
    {
        RuleFor(x => x.Visit.Id).NotEmpty().WithMessage("VisitId is required");
        RuleFor(x => x.Visit.DoctorId).NotEmpty().WithMessage("Visit.DoctorId is required");
        RuleFor(x => x.Visit.PatientId).NotEmpty().WithMessage("Visit.PatientId is required");
        RuleFor(x => x.Visit.EndDate).LessThan(x => x.Visit.StartDate).WithMessage("EndDate should be > StartDate");
        RuleFor(x => x.Visit.LocationVisit).NotEmpty().WithMessage("Visit.LocationVisit is required");
    }
}