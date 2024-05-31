using Registration.Application.Dtos;
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

            if (command.History == null || command.History?.RegisterId == null || command.History.RegisterId == Guid.Empty)
            {
                throw new ArgumentNullException("Register Id is required for creating a history");
            }
            var riskFactor = CreateNewHistory(command.History);

            dbContext.Histories.Add(riskFactor);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateHistoryResult(riskFactor.Id.Value);
        }

        public static History CreateNewHistory(HistoryDto history, Guid? registerId = null)
        {
            Guid finalRegisterId = registerId ?? (history?.RegisterId ?? Guid.Empty);

            var newHistory = History.Create(
                id: HistoryId.Of(Guid.NewGuid()),
                date: DateTime.Now,
                status: history?.Status ?? HistoryStatus.Registered,
                registerId: RegisterId.Of(finalRegisterId)

                );
            return newHistory;
        }
    }
}