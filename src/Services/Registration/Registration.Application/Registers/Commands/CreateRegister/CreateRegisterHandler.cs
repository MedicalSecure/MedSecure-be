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
                    id: PatientId.Of(Guid.NewGuid()),
                    firstName: registerDto.Patient.FirstName,
                    lastName: registerDto.Patient.LastName,
                    dateOfBirth: registerDto.Patient.DateOfBirth,
                    identity: registerDto.Patient.Identity,
                    cnam: registerDto.Patient.CNAM,
                    assurance: registerDto.Patient.Assurance,
                    gender: registerDto.Patient.Gender,
                    height: registerDto.Patient.Height,
                    weight: registerDto.Patient.Weight,
                    addressIsRegisterations: registerDto.Patient.AddressIsRegistrations,
                    saveForNextTime: registerDto.Patient.SaveForNextTime,
                    email: registerDto.Patient.Email,
                    address1: registerDto.Patient.Address1,
                    address2: registerDto.Patient.Address2,
                    country: registerDto.Patient.Country,
                    state: registerDto.Patient.State,
                    zipCode: registerDto.Patient.ZipCode,
                    familyStatus: registerDto.Patient.FamilyStatus,
                    children: registerDto.Patient.Children)
                );

            return newRegister;
        }
    }
}
