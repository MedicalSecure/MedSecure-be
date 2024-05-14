using System.Data;

namespace Registration.Application.Histories.Commands.CreateHistory
{
    public record CreateHistoryCommand(HistoryDto History): ICommand<CreateHistoryResult>;
    public record CreateHistoryResult(Guid Id);
    public class CreateHistoryValidator : AbstractValidator<CreateHistoryCommand>
     
    {
        public CreateHistoryValidator()
        {
            RuleFor(x => x.History.Status).NotEmpty();
        }
    }
}
