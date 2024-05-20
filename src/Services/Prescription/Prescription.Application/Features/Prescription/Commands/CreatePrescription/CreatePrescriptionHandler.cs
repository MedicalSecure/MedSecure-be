using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Exceptions;
using Prescription.Application.Features.UnitCare.Queries;
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
            try
            {
                // Create Prescription entity from command object
                var prescription = await CreateNewPrescription(command.Prescription, cancellationToken);

                // Save to database
                _dbContext.Prescriptions.Add(prescription);

                Guid createdBy = Guid.NewGuid();
                var newActivity = Domain.Entities.Activity.Create(createdBy, $"Created new {nameof(Prescription)}", "Hammadi AZ");
                _dbContext.Activities.Add(newActivity);

                await _dbContext.SaveChangesAsync(cancellationToken);
                // Return result
                return new CreatePrescriptionResult(prescription.Id.Value);
            }
            catch (Exception ex)
            {
                // Option 1: Return a custom error result
                //return new CreatePrescriptionResult(Guid.Empty);

                // Option 2: Throw a custom exception with the error message
                throw new CreatePrescriptionException(ex.Message, ex);
            }
        }

        private async Task<Domain.Entities.Prescription?> CreateNewPrescription(PrescriptionCreateDto prescriptionDto, CancellationToken cancellationToken)
        {
            var bed = await GetAvailableRoomFromUnitCare(prescriptionDto.UnitCare, cancellationToken);

            if (bed == null)
            {
                throw new Exception($"Cant find empty room for new prescription in UnitCare : {prescriptionDto.UnitCare.Title}");
                //return null;
            }

            var dietId = prescriptionDto.DietId.HasValue ? DietId.Of(prescriptionDto.DietId.Value) : null;

            var newPrescription = Domain.Entities.Prescription.Create(
                    RegisterId: RegisterId.Of(prescriptionDto.RegisterId),
                    doctorId: DoctorId.Of(prescriptionDto.DoctorId),
                    bedId: EquipmentId.Of(bed.Id),
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
                        //here we can enable creating new diagnosis if we want (add diagnosis in the front must be enabled ...)
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
                        //here we can enable creating new symptom if we want (add symptom in the front must be enabled ...)
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

            foreach (var posology in prescriptionDto.Posologies)
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
                        QuantityBM: dispense.BeforeMeal?.Quantity,
                        QuantityAM: dispense.AfterMeal?.Quantity,
                        createdBy: createdBy_DoctorId);

                    newPosology.AddDispense(newDispense);
                }

                if (newPosology != null) newPrescription.AddPosology(newPosology);
            }

            if (diagnosisEntities?.Count > 0) newPrescription.AddDiagnosis(diagnosisEntities);
            if (diagnosisEntities?.Count > 0) newPrescription.AddSymptoms(symptomsEntities);

            return newPrescription;
        }

        private async Task<EquipmentDto?> GetAvailableRoomFromUnitCare(UnitCareDto unitCare, CancellationToken cancellationToken)
        {
            var handler = new GetOccupiedRoomsHandler(_dbContext);

            var req = new GetOccupiedRoomsQuery(new PaginationRequest(0, -1));
            var occupiedRoomsResult = await handler.Handle(req, cancellationToken);
            var occupiedRooms = occupiedRoomsResult?.OccupiedRooms?.Data?.ToArray();
            var allRoomsAreAvailable = occupiedRooms == null || occupiedRooms.Length == 0;

            if (occupiedRooms != null)
                foreach (var room in unitCare.Rooms)
                {
                    foreach (var equipment in room.Equipments)
                    {
                        if (equipment == null) continue;
                        //TODO verify bed name

                        if (equipment.Name == "Bed" && allRoomsAreAvailable)
                        {
                            return equipment;
                        }
                        else if (equipment.Name == "Bed" && !occupiedRooms.Contains(EquipmentId.Of(equipment.Id)))
                            return equipment;
                    }
                }
            return null;
        }
    }
}