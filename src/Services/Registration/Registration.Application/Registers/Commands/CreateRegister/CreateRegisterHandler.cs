namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateRegisterHandler(IApplicationDbContext dbContext) :ICommandHandler<CreateRegisterCommand,CreateRegisterResult>
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
                id: RegisterId.Of(registerDto.Id),
                patient: Patient.Create(
                    id: PatientId.Of(registerDto.Patient.Id),
                    firstName: registerDto.Patient.FirstName ?? "",
                    lastName: registerDto.Patient.LastName ?? "",
                    dateOfBirth: registerDto.Patient.DateOfBirth,
                    identity: registerDto.Patient.Identity ?? "",
                    cnam: registerDto.Patient.CNAM ?? 0, // Assuming default value for CNAM is 0
                    assurance: registerDto.Patient.Assurance ?? "",
                    gender: registerDto.Patient.Gender ?? Gender.Female, // Assuming default value for Gender is Unknown
                    height: registerDto.Patient.Height ?? 0, // Assuming default value for Height is 0
                    weight: registerDto.Patient.Weight ?? 0, // Assuming default value for Weight is 0
                    addressIsRegisterations: registerDto.Patient.AddressIsRegistrations ?? false, // Assuming default value for AddressIsRegistrations is false
                    saveForNextTime: registerDto.Patient.SaveForNextTime ?? false, // Assuming default value for SaveForNextTime is false
                    email: registerDto.Patient.Email ?? "",
                    address1: registerDto.Patient.Address1 ?? "",
                    address2: registerDto.Patient.Address2 ?? "",
                    country: registerDto.Patient.Country ?? Country.TN, // Assuming default value for Country is Unknown
                    state: registerDto.Patient.State ?? "",
                    zipCode: registerDto.Patient.ZipCode ?? 0, // Assuming default value for ZipCode is 0
                    familyStatus: registerDto.Patient.FamilyStatus ?? FamilyStatus.SINGLE, // Assuming default value for FamilyStatus is Unknown
                    children: registerDto.Patient.Children ?? Children.None // Assuming default value for Children is Unknown
                )
            );

            return register;
        }

    }
}
