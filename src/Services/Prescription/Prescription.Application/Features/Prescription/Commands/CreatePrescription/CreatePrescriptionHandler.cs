using Prescription.Application.Contracts;

namespace Prescription.Application.Features.Prescription.Commands.CreatePrescription
{
    public class CreatePrescriptionHandler : ICommandHandler<CreatePrescriptionCommand, CreatePrescriptionResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public CreatePrescriptionHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<CreatePrescriptionResult> Handle(CreatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            // Create Prescription entity from command object
            var prescription = await CreateNewPrescription(command.Prescription, cancellationToken);

            // Save to database
            _dbContext.Prescriptions.Add(prescription);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Return result
            return new CreatePrescriptionResult(prescription.Id.Value);
        }

        private Task<Domain.Entities.PrescriptionRoot.Prescription>? CreateNewPrescription(PrescriptionDto prescriptionDto, CancellationToken cancellationToken)
        {
            //var newPrescription = PrescriptionEntity.Create(patient.Adapt<Patient>(_mapsterConfig), doctor.Adapt<Doctor>(_mapsterConfig));
            var newPrescription = prescriptionDto.Adapt<Domain.Entities.PrescriptionRoot.Prescription>(_mapsterConfig);

            var diagnosisEntities = prescriptionDto.Diagnoses
                .Select(dto => dto.Adapt<Domain.Entities.Diagnosis>(_mapsterConfig))
                .ToList();

            //newPrescription.addDiagnosis(diagnosisEntities);

            return null;
        }
    }

    /*public class CreatePrescriptionHandler(IApplicationDbContext dbContext, IPatientService patientService) : ICommandHandler<CreatePrescriptionCommand, CreatePrescriptionResult>
    {
        public async Task<CreatePrescriptionResult> Handle(CreatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            // create Prescription entity from command object
            // save to database
            // return result
            var Prescription = await CreateNewPrescription(command.Prescription, cancellationToken);

            dbContext.Prescriptions.Add(Prescription);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePrescriptionResult(Prescription.Id);
        }

        private static async Task<PrescriptionEntity> CreateNewPrescription(PrescriptionDto PrescriptionDto, CancellationToken cancellationToken)
        {
            Doctor doctor = patientService.GetPatientByIdAsync(PrescriptionDto.PatientId, cancellationToken); ;
            Patient patient =;
            var newPrescription = PrescriptionEntity.Create(patient, doctor);

            List<Domain.Entities.Diagnosis> diagnosisEntities = PrescriptionDto
                .Diagnoses
                .Select(dto => dto.Adapt<Domain.Entities.Diagnosis>())
                .ToList();
            newPrescription.addDiagnosis(diagnosisEntities);
            return newPrescription;
        }
    }*/
}