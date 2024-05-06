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
                  patient: Patient.Create(
                    Id: PatientId.Of(Guid.NewGuid()),
                    firstName: registerDto.patient.firstName,
                    lastName: registerDto.patient.lastName,
                    dateOfbirth: registerDto.patient.dateOfBirth,
                    cin: registerDto.patient.cin,
                    cnam: registerDto.patient.cnam,
                    assurance: registerDto.patient.assurance,
                    gender: registerDto.patient.gender,
                    height: registerDto.patient.height,
                    weight: registerDto.patient.weight,
                    addressIsRegisteraions: registerDto.patient.addressIsRegisteraions,
                    saveForNextTime: registerDto.patient.saveForNextTime,
                    email: registerDto.patient.email,
                    address1: registerDto.patient.address1,
                    address2: registerDto.patient.address2,
                    country: registerDto.patient.country,
                    state: registerDto.patient.state,
                    zipCode: registerDto.patient.zipCode,
                    familyStatus: registerDto.patient.familyStatus,
                    children: registerDto.patient.children),
                test:registerDto.test
                );

            return newRegister;
        }
    }
}
