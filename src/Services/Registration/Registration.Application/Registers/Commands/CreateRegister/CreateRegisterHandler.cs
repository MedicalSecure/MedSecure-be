namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateRegisterHandler(IApplicationDbContext dbContext) :ICommandHandler<CreateRegisterCommand,CreateRegisterResult>
    {
        public async Task<CreateRegisterResult> Handle(CreateRegisterCommand command, CancellationToken cancellationToken)
        {
            // create register entity from command object
            // save to database
            // return result
            var register = CreateNewRegister(command.Register);

            dbContext.Registers.Add(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateRegisterResult(register.Id.Value);
        }

        private static Domain.Models.Register CreateNewRegister(RegisterDto registerDto)
        {
            var newRegister = Domain.Models.Register.Create(
                id: RegisterId.Of(Guid.NewGuid()),
                patientId: PatientId.Of(registerDto.patientId),
                patient:registerDto.patient,
                familyHistory: registerDto.familyHistory,
                personalHistory: registerDto.personalHistory,
                disease:registerDto.disease,
                allergy:registerDto.allergy
                );

            return newRegister;
        }
    }
}
