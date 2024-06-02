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

            var registerId = RegisterId.Of(command.History.RegisterId);
            var register = await dbContext.Registers
                    .Include(reg => reg.History)
                    .FirstOrDefaultAsync(reg => reg.Id == registerId, cancellationToken);

            if (register == null)
                throw new RegisterNotFoundException(registerId.Value);

            //will throw the Invalid operation errors!!
            var riskFactor = CreateNewHistory(command.History, register);

            dbContext.Histories.Add(riskFactor);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateHistoryResult(riskFactor.Id.Value);
        }

        public static History CreateNewHistory(HistoryDto newHistory, Register register)
        {
            var lastHistoryStatus = register.GetRegistrationStatus();
            // if archived, we cant edit him, except for a new registration => handled by Unarchive endpoint
            if (register.Status == RegisterStatus.Archived)
                throw new InvalidOperationException("Can't add a new history for an archived patient, please use the register/status endpoint");

            /*
             * This endpoint is intended to be used by the doctor, so we have two possible cases:
             * 1) the patient in registered => can be changed to OUT or Resident 
             * 2) the patient is resident => can be changed only to OUT
             
             *any other cases will throw an error, because they require the archiving status of the register to be modified, 
             *so doing it with the Archive/Unarchive endpoint : registers/status makes more sense
             *that endpoint will add the corresponding History to the modified register object too !
              
             
             */
            if (lastHistoryStatus == HistoryStatus.Registered)
            {
                if (newHistory.Status == HistoryStatus.Registered)
                    throw new InvalidOperationException("Can't create a new Registered history for already registered patient");

                //Continue creating the Out or Resident status, this is the only accessible post histories for doctor,
                //receptionist can use Archive and UnArchive endpoints To add other types of history
            }
            else if(lastHistoryStatus == HistoryStatus.Resident)
            {
                if (newHistory.Status == HistoryStatus.Resident)
                    throw new InvalidOperationException("Can't create a new Resident history for already Resident patient");
                else if (newHistory.Status == HistoryStatus.Registered)
                    throw new InvalidOperationException("Can't create a new Registered history for already Resident patient");
                //Continue creating the Out status, this is the only accessible post histories for doctor,
                //receptionist can use Archive and UnArchive endpoints To add other types of history
            }
            else
            {
                string lastHistory = lastHistoryStatus == HistoryStatus.Out ? "Out" : "Resident";
                // Other cases must be handled by Archive and UnArchive endpoints !! for the receptionist access
                if (newHistory.Status == HistoryStatus.Registered)
                    throw new InvalidOperationException($"Can't create a new Registered history for ${lastHistory} patient, please use the register/status endpoint");
                else if (newHistory.Status == HistoryStatus.Out)
                    throw new InvalidOperationException($"Can't create a new Out history for ${lastHistory} patient, please use the register/status endpoint");
                else if (newHistory.Status == HistoryStatus.Resident)
                    throw new InvalidOperationException($"Can't create a new Resident history for ${lastHistory} patient, please use the register/status endpoint");
            }

            // Here : the only possible case to add is : (the last history is REGISTERED) + (The new one is OUT or Resident)    (normally by the doctor)
            var newFinalHistory = History.Create(
                id: HistoryId.Of(Guid.NewGuid()),
                date: DateTime.Now,
                status: newHistory.Status,
                registerId: register.Id
                );
            return newFinalHistory;
        }
    }
}