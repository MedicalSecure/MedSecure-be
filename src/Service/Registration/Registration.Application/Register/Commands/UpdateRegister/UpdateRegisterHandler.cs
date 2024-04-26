
using BuildingBlocks.CQRS;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Application.Exceptions;
using Registration.Domain.ValueObjects;

namespace Registration.Application.Register.Commands.UpdateRegister
{
    public class UpdateRegisterHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateRegisterCommand, UpdateRegisterResult>
    {
        public async Task<UpdateRegisterResult> Handle(UpdateRegisterCommand command, CancellationToken cancellationToken)
        {
            // Update Patient entity from command object
            // save to database
            // return result
            var registerId = RegisterId.Of(command.Register.Id);
            var register = await dbContext.Registers.FindAsync([registerId], cancellationToken);

            if (register == null)
            {
                throw new RegisterNotFoundException(command.Register.Id);
            }

            UpdateRegisterWithNewValues(register, command.Register);

            dbContext.Registers.Update(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateRegisterResult(true);
        }

        private static void UpdateRegisterWithNewValues(Domain.Models.Register register, RegisterDto registerDto)
        {
            register.Update(registerDto.familyHistory, registerDto.personalHistory);
        }

    }
    
}
