using Prescription.Application.Contracts;
using Prescription.Domain.Entities;
using Prescription.Domain.ValueObjects;

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
            var prescription = CreateNewPrescription(command.Prescription, cancellationToken);

            // Save to database
            _dbContext.Prescriptions.Add(prescription);
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception x)
            {
                throw x;
            }

            // Return result
            return new CreatePrescriptionResult(prescription.Id.Value);
        }

        private Domain.Entities.Prescription? CreateNewPrescription(PrescriptionCreateDto prescriptionDto, CancellationToken cancellationToken)
        {
            //var newPrescription = prescriptionDto.Adapt<Domain.Entities.Prescription>(_mapsterConfig);

            var unitCareId = prescriptionDto.UnitCareId.HasValue ? UnitCareId.Of(prescriptionDto.UnitCareId.Value) : null;
            var dietId = prescriptionDto.DietId.HasValue ? DietId.Of(prescriptionDto.DietId.Value) : null;

            var newPrescription = Domain.Entities.Prescription.Create(
                    RegisterId: RegisterId.Of(prescriptionDto.RegisterId),
                    doctorId: DoctorId.Of(prescriptionDto.DoctorId),
                    unitCareId: unitCareId,
                    dietId: dietId
                );
            string createdBy_DoctorId = newPrescription.CreatedBy!;

            var diagnosisEntities = prescriptionDto.Diagnoses
                .Select(dto =>
                {
                    var diagnosis = _dbContext.Diagnosis.Find(DiagnosisId.Of(dto.Id));
                    if (diagnosis != null)
                    {
                        _dbContext.AttachEntity(diagnosis);
                        return diagnosis;
                    }
                    else
                    {
                        return null;
                        //here we can enable creating new diagnosis if we want
                        /*return Domain.Entities.Diagnosis.Create(
                            DiagnosisId.Of(dto.Id),
                            dto.Code,
                            dto.Name,
                            dto.ShortDescription,
                            dto.LongDescription
                        );*/
                    }
                })
                .Where(diagnosis => diagnosis != null)
                .ToList();

            var symptomsEntities = prescriptionDto.Symptoms
                .Select(dto =>
                {
                    var symptom = _dbContext.Symptoms.Find(SymptomId.Of(dto.Id));
                    if (symptom != null)
                    {
                        _dbContext.AttachEntity(symptom);
                        return symptom;
                    }
                    else
                    {
                        return null;
                        //here we can enable creating new symptom if we want
                        /*return Domain.Entities.Symptom.Create(
                            SymptomId.Of(dto.Id),
                            dto.Code,
                            dto.Name,
                            dto.ShortDescription,
                            dto.LongDescription
                        );*/
                    }
                })
                .Where(symptom => symptom != null)
                .ToList();

            var posologies = prescriptionDto.Posologies.Select((posology) =>
            {
                var newPosology = Posology.Create(
                    prescriptionId: newPrescription.Id,
                    medicationId: MedicationId.Of(posology.MedicationId),
                    startDate: posology.StartDate,
                    endDate: posology.EndDate,
                    isPermanent: posology.IsPermanent,
                    createdBy: createdBy_DoctorId);
                foreach (var comment in posology.Comments)
                {
                    var newComment = Comment.Create(
                        posologyId: newPosology.Id,
                        label: comment.Label,
                        content: comment.Content,
                        createdBy: createdBy_DoctorId);

                    newPosology.AddComment(newComment);
                }
                foreach (var dispense in posology.Dispenses)
                {
                    var newDispense = Dispense.Create(
                        posologyId: newPosology.Id,
                        hour: dispense.Hour,
                        QuantityBM: dispense.BeforeMeal.Quantity,
                        QuantityAM: dispense.AfterMeal.Quantity,
                        createdBy: createdBy_DoctorId);

                    newPosology.AddDispense(newDispense);
                }

                newPrescription.addPosology(newPosology);
                return newPosology;
            });

            //TODO sometimes posology doesnt work, no errors, cant debug!! verify it with this code later
            /*            var posology = prescriptionDto.Posologies.First();

                        var newPosology = Posology.Create(
                        prescriptionId: newPrescription.Id,
                                medicationId: MedicationId.Of(posology.MedicationId),
                        startDate: posology.StartDate,
                                endDate: posology.EndDate,
                                isPermanent: posology.IsPermanent,
                                createdBy: createdBy_DoctorId);
                        foreach (var comment in posology.Comments)
                        {
                            var newComment = Comment.Create(
                                posologyId: newPosology.Id,
                                label: comment.Label,
                                content: comment.Content,
                                createdBy: createdBy_DoctorId);

                            newPosology.AddComment(newComment);
                        }
                        foreach (var dispense in posology.Dispenses)
                        {
                            var newDispense = Dispense.Create(
                                posologyId: newPosology.Id,
                                hour: dispense.Hour,
                                QuantityBM: dispense.BeforeMeal.Quantity,
                                QuantityAM: dispense.AfterMeal.Quantity,
                                createdBy: createdBy_DoctorId);

                            newPosology.AddDispense(newDispense);
                        }

                        newPrescription.addPosology(newPosology);
            */

            newPrescription.addDiagnosis(diagnosisEntities);
            newPrescription.addSymptoms(symptomsEntities);

            return newPrescription;
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