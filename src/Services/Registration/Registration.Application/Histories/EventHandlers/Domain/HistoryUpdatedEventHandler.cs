using Registration.Application.Histories.Commands.CreateHistory;

namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateHistoryHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateHistoryCommand, CreateHistoryResult>
    {
        public async Task<CreateHistoryResult> Handle(CreateHistoryCommand command, CancellationToken cancellationToken)
        {
            var history = CreateNewHistory(command.History);

            dbContext.Histories.Add(history);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateHistoryResult(history.Id.Value);
        }

        private static History CreateNewHistory(HistoryDto historyDto)
        {
            var newHistory = History.Create(
                id: HistoryId.Of(Guid.NewGuid()),
                date: historyDto.date,
                status: historyDto.status,
                registerId: historyDto.registerId
            );

            return newHistory;
        }
    }
}
