using Registration.Application.Histories.Commands.UpdateHistory;

namespace Registration.Application.Histories.Commands.CreateHistory
{
    public class UpdateHistoryHandler : ICommandHandler<UpdateHistoryCommand, UpdateHistoryResult>
    {
        private readonly IApplicationDbContext dbContext;

        public UpdateHistoryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UpdateHistoryResult> Handle(UpdateHistoryCommand command, CancellationToken cancellationToken)
        {
            // create history entity from command object
            // save to database
            // return result
/*            var history = CreateNewHistory(command.History);

            dbContext.Histories.Add(history);
            await dbContext.SaveChangesAsync(cancellationToken);*/

            return new UpdateHistoryResult(false);
        }

        private static History CreateNewHistory(HistoryDto historyDto)
        {
            var newHistory = History.Create(
                id: HistoryId.Of(Guid.NewGuid()),
                date: historyDto.Date ,
                status: historyDto.Status,
                registerId: RegisterId.Of(historyDto.RegisterId) 
            );

            return newHistory;
        }
    }
}
