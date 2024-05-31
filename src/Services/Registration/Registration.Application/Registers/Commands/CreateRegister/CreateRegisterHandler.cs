using Registration.Application.Patients.Commands.CreatePatient;

namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateRegisterHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateRegisterCommand, CreateRegisterResult>
    {
        public async Task<CreateRegisterResult> Handle(CreateRegisterCommand command, CancellationToken cancellationToken)
        {
            // create register entity from command object
            // save to database
            // return result
            var register = CreateNewRegister(command.register);

            dbContext.Registers.Add(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateRegisterResult(register.Id.Value);
        }

        private static Domain.Models.Register CreateNewRegister(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                throw new ArgumentNullException(nameof(registerDto), "RegisterDto cannot be null");
            }

            if (registerDto.Patient == null)
            {
                throw new ArgumentNullException(nameof(registerDto.Patient), "PatientDto cannot be null");
            }

            // Accessing properties with null checks and providing default values if they are null
            var register = Domain.Models.Register.Create(
                id: RegisterId.Of(Guid.NewGuid()),
                patient: CreatePatientHandler.CreateNewPatient(registerDto.Patient)
            );

            return register;
        }
    }
}