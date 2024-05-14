namespace Registration.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientHandler : ICommandHandler<UpdatePatientCommand, UpdatePatientResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdatePatientHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdatePatientResult> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var patientId = PatientId.Of(command.Patient.Id);
            var patient = await _dbContext.Patients.FindAsync(new object[] { patientId }, cancellationToken);

            if (patient == null)
            {
                throw new PatientNotFoundException(command.Patient.Id);
            }

            UpdatePatientWithNewValues(patient, command.Patient);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePatientResult(true);
        }

        private static void UpdatePatientWithNewValues(Patient patient, PatientDto patientDto)
        {
            
            patient.Update(
                patientDto.FirstName ?? patient.FirstName,
                patientDto.LastName ?? patient.LastName,
                patientDto.DateOfBirth,
                patientDto.Identity ?? patient.Identity,
                patientDto.CNAM ?? patient.CNAM,
                patientDto.Gender ?? patient.Gender,
                patientDto.Height ?? patient.Height,
                patientDto.Weight ?? patient.Weight,
                patientDto.Email ?? patient.Email,
                patientDto.Address1 ?? patient.Address1,
                patientDto.Address2 ?? patient.Address2,
                patientDto.Country ?? patient.Country,
                patientDto.State ?? patient.State,
                patientDto.FamilyStatus ?? patient.FamilyStatus,
                patientDto.Children ?? patient.Children);
        }
    }
}
