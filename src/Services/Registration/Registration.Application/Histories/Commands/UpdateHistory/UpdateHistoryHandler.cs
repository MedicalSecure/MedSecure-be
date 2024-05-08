namespace Registration.Application.Histories.Commands.CreateHistory
{
    public class UpdateHistoryHandler : ICommandHandler<CreateHistoryCommand, CreateHistoryResult>
    {
        private readonly IApplicationDbContext dbContext;

        public UpdateHistoryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateHistoryResult> Handle(CreateHistoryCommand command, CancellationToken cancellationToken)
        {
            // create history entity from command object
            // save to database
            // return result
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
