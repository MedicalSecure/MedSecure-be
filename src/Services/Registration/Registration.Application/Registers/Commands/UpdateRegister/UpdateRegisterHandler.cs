using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Registration.Application.Registers.Commands.UpdateRegister
{
    public class UpdateRegisterHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateRegisterCommand, UpdateRegisterResult>
    {
        public async Task<UpdateRegisterResult> Handle(UpdateRegisterCommand command, CancellationToken cancellationToken)
        {
            // Update Patient entity from command object
            // save to database
            // return result

            if (command.Register.Id == null)
                throw new MissingFieldException("RegisterId is required for updating");

            var registerId = RegisterId.Of(command.Register.Id ?? Guid.NewGuid());
            var register = await dbContext.Registers.FindAsync([registerId], cancellationToken);

            if (register == null)
            {
                throw new RegisterNotFoundException(command.Register.Id ?? Guid.NewGuid());
            }

            UpdateRegister(register, command.Register);

            dbContext.Registers.Update(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateRegisterResult(true);
        }

        private static void UpdateRegister(Domain.Models.Register existingRegister, RegisterDto newRegisterDto)
        {
        }
    }
}