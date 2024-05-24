using Registration.Application.RiskFactors.Commands.CreateRiskFactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Histories.Commands.CreateHistory
{
    public class CreateHistoryHandler
    (IApplicationDbContext dbContext) : ICommandHandler<CreateHistoryCommand, CreateHistoryResult>
    {
        public async Task<CreateHistoryResult> Handle(CreateHistoryCommand command, CancellationToken cancellationToken)
        {
            // create Patient entity from command object
            // save to database
            // return result
            var riskFactor = CreateNewHistory(command.History);

            dbContext.Histories.Add(riskFactor);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateHistoryResult(riskFactor.Id.Value);
        }

        private static History CreateNewHistory(HistoryDto history)
        {
            var newHistory = History.Create(
                id: HistoryId.Of(Guid.NewGuid()),
                date: DateTime.Now,
                status: history.Status,
                registerId: RegisterId.Of(history.RegisterId)

                );

            return newHistory;
        }
    }
}