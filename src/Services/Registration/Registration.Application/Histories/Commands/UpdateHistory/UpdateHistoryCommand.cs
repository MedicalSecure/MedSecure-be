namespace Registration.Application.Histories.Commands.UpdateHistory
{
    public record UpdateHistoryCommand(HistoryDto History) : ICommand<UpdateHistoryResult>;
    public record UpdateHistoryResult(bool IsSuccess);

    public class UpdateHistoryCommandValidator : AbstractValidator<UpdateHistoryCommand>
    {
        public UpdateHistoryCommandValidator()
        {
            RuleFor(x => x.History.status).NotEmpty().WithMessage("HistoryId is required");
        }
    }
}
