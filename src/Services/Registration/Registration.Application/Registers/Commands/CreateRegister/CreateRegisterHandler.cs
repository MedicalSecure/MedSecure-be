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
                
                patient:Patient.Create(
                    
                    registerDto.patient.firstName,
                    registerDto.patient.lastName,
                    registerDto.patient.dateOfbirth,
                    registerDto.patient.cin,
                    registerDto.patient.cnam,
                    registerDto.patient.gender,
                    registerDto.patient.height,
                    registerDto.patient.weight,
                    registerDto.patient.email,
                    registerDto.patient.address1,
                    registerDto.patient.address2,
                    registerDto.patient.country,
                    registerDto.patient.state,
                    registerDto.patient.familyStatus,
                    registerDto.patient.children

                    ),
                familyHistory: registerDto.familyHistory,
                personalHistory: registerDto.personalHistory,
                disease:registerDto.disease,
                allergy:registerDto.allergy
                );

            return newRegister;
        }
    }
}
