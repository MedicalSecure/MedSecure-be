using BuildingBlocks.Messaging.Events.RegistrationEvents;
using BuildingBlocks.Messaging.Events.RegistrationSharedEvents;
using Registration.Application.Histories.Commands.CreateHistory;
using Registration.Domain.ValueObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Registration.Application.Registers.Commands.ArchiveUnarchiveRegister
{
    public class ArchiveUnarchiveRegisterHandler(IApplicationDbContext dbContext, IPublishEndpoint publisher) : ICommandHandler<ArchiveUnarchiveRegisterCommand, ArchiveUnarchiveRegisterResult>
    {
        public async Task<ArchiveUnarchiveRegisterResult> Handle(ArchiveUnarchiveRegisterCommand command, CancellationToken cancellationToken)
        {
            // Archive Patient entity from command object
            // save to database
            // return result

            if (command.registerId == Guid.Empty)
                throw new MissingFieldException("RegisterId is required for archiving");

            var registerId = RegisterId.Of(command.registerId);
            var register = await dbContext.Registers
                 .Include(reg => reg.History)
                //for filling the shared event
                .Include(t => t.Patient)
                .Include(t => t.Tests)
                .Include(r => r.FamilyMedicalHistory)
                .Include(r => r.PersonalMedicalHistory)
                .Include(r => r.Disease)
                .Include(r => r.Allergy)
                 .FirstOrDefaultAsync(reg => reg.Id == registerId, cancellationToken);

            if (register == null)
                throw new RegisterNotFoundException(registerId.Value);

            //will archive/unarchive the register
            // in archiving : will add a new Out history (if its not already created) => wont throw an error if he is already out
            // will throw an error if he is already archived or no history found for him
            //
            // in Unarchiving : will add a new Resident history (if its not already created) => wont throw an error if he is already Resident
            // will throw an error if he is already active or no history found for him
            if (command.registerStatus == RegisterStatus.Archived)
                //the new status is archive=> try archiving the patient
                register.Archive();
            else
                //the new status is active=> try unarchiving the patient
                register.Unarchive();

            dbContext.Registers.Update(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Handle sending the event
            if (command.registerStatus == RegisterStatus.Archived)
            {
                var archivedEvent = new ArchiveRegisterSharedEvent(register.Id.Value);
                await publisher.Publish(archivedEvent);
            }
            else
            {
                //Auto include the riskFactors
                var riskFactor = await dbContext.RiskFactors.ToListAsync(cancellationToken);
                RegisterDto registerTomap = register.ToRegisterDto();
                RegisterSharedEvent registerToSend = registerTomap.Adapt<RegisterSharedEvent>();
                var eventToSend = new NewRegisterSharedEvent(registerToSend);
                await publisher.Publish(eventToSend);
            }

            return new ArchiveUnarchiveRegisterResult(register.Id.Value.ToString());
        }
    }
}