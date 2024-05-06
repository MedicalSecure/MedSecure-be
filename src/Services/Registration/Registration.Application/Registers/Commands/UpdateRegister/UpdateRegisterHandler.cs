namespace Registration.Application.Registers.Commands.UpdateRegister
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

            UpdateRegister(register, command.Register);

            dbContext.Registers.Update(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateRegisterResult(true);
        }

        private static void UpdateRegister(Domain.Models.Register existingRegister, RegisterDto newRegisterDto)
        {
            // Update the properties of the existing register with the data from the new DTO
            existingRegister.Patient.FirstName = newRegisterDto.patient.firstName;
            existingRegister.Patient.LastName = newRegisterDto.patient.lastName;
            existingRegister.Patient.DateOfBirth = newRegisterDto.patient.dateOfBirth;
            existingRegister.Patient.CIN = newRegisterDto.patient.cin;
            existingRegister.Patient.CNAM = newRegisterDto.patient.cnam;
            existingRegister.Patient.Gender = newRegisterDto.patient.gender;
            existingRegister.Patient.Height = newRegisterDto.patient.height;
            existingRegister.Patient.Weight = newRegisterDto.patient.weight;
            existingRegister.Patient.Email = newRegisterDto.patient.email;
            existingRegister.Patient.Address1 = newRegisterDto.patient.address1;
            existingRegister.Patient.Address2 = newRegisterDto.patient.address2;
            existingRegister.Patient.Country = newRegisterDto.patient.country;
            existingRegister.Patient.State = newRegisterDto.patient.state;
            existingRegister.Patient.FamilyStatus = newRegisterDto.patient.familyStatus;
            existingRegister.Patient.Children = newRegisterDto.patient.children;
        }
    }

}
