using BuildingBlocks.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Exceptions;
using Prescription.Application.Features.UnitCare.Queries;
using Prescription.Domain.Entities;
using Prescription.Domain.Entities.UnitCareRoot;
using Prescription.Domain.ValueObjects;

namespace Prescription.Application.Features.Prescription.Commands.UpdatePrescription
{
    public class UpdatePrescriptionHandler : ICommandHandler<UpdatePrescriptionCommand, UpdatePrescriptionResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public UpdatePrescriptionHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<UpdatePrescriptionResult> Handle(UpdatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Get the old prescription from DB so we can update the status
                var prescriptionId = PrescriptionId.Of(command.Prescription.Id
                    ?? throw new BadRequestException($"{nameof(Prescription)} : Updating a prescription Require an ID"));

                var oldPrescription = await _dbContext.Prescriptions.FindAsync([prescriptionId], cancellationToken)
                    ?? throw new NotFoundException($"{nameof(Prescription)} : Can't find prescription to update with the given id : {prescriptionId.Value}");

                // Update Prescription entity from command object
                var newPrescription = await CreateNewPrescription(command.Prescription, oldPrescription, cancellationToken);

                // Save to database
                _dbContext.Prescriptions.Add(newPrescription);

                // the new prescription is valid (didn't throw exception) so we can update the status of the old one
                oldPrescription.UpdateStatus(PrescriptionStatus.Discontinued);

                // the UpdateStatus Didn't throw a an exception => the new status (Discontinued) is valid relative to the old one, we can save changes!
                _dbContext.Prescriptions.Update(oldPrescription);

                //Create correspanding activity
                Guid createdBy = Guid.NewGuid();
                var newActivity = Domain.Entities.Activity.Create(createdBy, $"Updated a {nameof(Prescription)}", "Hammadi AZ");
                _dbContext.Activities.Add(newActivity);

                // Same the 3 changes : update old prescription (discontinued), Add the new one AND Add an activity
                await _dbContext.SaveChangesAsync(cancellationToken);
                // Return result
                return new UpdatePrescriptionResult(newPrescription.Id.Value);
            }
            catch (Exception ex)
            {
                // Option 1: Return a custom error result
                //return new UpdatePrescriptionResult(Guid.Empty);

                // Option 2: Throw a custom exception with the error message
                throw new UpdatePrescriptionException(ex.Message, ex);
            }
        }

        private async Task<Domain.Entities.Prescription> CreateNewPrescription(PrescriptionCreateUpdateDto prescriptionDto, Domain.Entities.Prescription oldPrescription, CancellationToken cancellationToken)
        {
            EquipmentId? bedId = null;
            var diet = prescriptionDto.Diet ?? null;
            if (prescriptionDto.UnitCare != null)
            {
                if (NewBedIsInSameUnitCare(prescriptionDto, oldPrescription) == false)
                {
                    EquipmentDTO? bed = null;
                    //try to search for new bed in the new unit care
                    bed = await GetAvailableBedFromUnitCare(prescriptionDto.UnitCare, cancellationToken);

                    if (bed == null)
                    {
                        throw new Exception($"Cant find empty room for new prescription in UnitCare : {prescriptionDto.UnitCare.Title}");
                        //return null;
                    }
                    bedId = EquipmentId.Of(bed.Id);
                }
                else
                {
                    // its the same Bed, get the id from the old prescription
                    bedId = oldPrescription.BedId;
                }
            }
            if (diet == null && bedId != null)
            {
                //unit care provided but no diet!!
                throw new Exception($"Hospitalized patients require a diet to be specified! : {prescriptionDto?.UnitCare?.Title}");
            }

            //now we continue with two cases:
            //1) diet==NULL and prescriptionDto.UnitCare==NULL => NON HOSPITALIZED PATIENT
            //2) we have a free bed and a selected diet => HOSPITALIZED PATIENT

            var newDiet = diet == null ? null : DietForPrescription.Create(
                                                        dietsId: diet.DietsId,
                                                        StartDate: new DateOnly(diet.StartDate.Date.Year, diet.StartDate.Date.Month, diet.StartDate.Date.Day).AddDays(1),
                                                        EndDate: new DateOnly(diet.EndDate.Date.Year, diet.EndDate.Date.Month, diet.EndDate.Date.Day).AddDays(-1));

            var newPrescription = Domain.Entities.Prescription.Create(
                    RegisterId: RegisterId.Of(prescriptionDto.RegisterId),
                    doctorId: DoctorId.Of(prescriptionDto.DoctorId),
                    bedId: bedId,
                    diet: newDiet
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
                        /*return Domain.Entities.Diagnosis.Update(
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
                        /*return Domain.Entities.Symptom.Update(
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

        private bool NewBedIsInSameUnitCare(PrescriptionCreateUpdateDto prescription, Domain.Entities.Prescription oldPrescription)
        {
            //this function will check if the doctor is trying to move the patient to new unit care
            //this checks if the bedId that he is already occupying, is in the same new UNIT CARE from the updated prescription
            var oldBedId = oldPrescription.BedId?.Value;
            var newDestinationUnitCare = prescription.UnitCare;
            //oldBedId==null : old prescription wasn't hospitalized but this one is!!
            //in case the new prescription is not hospitalized, its handled in the caller of this function (this function wont be called)

            if (newDestinationUnitCare == null || oldBedId == null) return false;
            foreach (var room in newDestinationUnitCare.Rooms)
            {
                foreach (var equipment in room.Equipments)
                {
                    if (equipment == null || equipment.EqType != EqType.bed) continue;

                    if (equipment.Id == oldBedId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<EquipmentDTO?> GetAvailableBedFromUnitCare(UnitCareDTO unitCare, CancellationToken cancellationToken)
        {
            var handler = new GetOccupiedBedsHandler(_dbContext);

            var req = new GetOccupiedBedsQuery(new PaginationRequest(0, -1));
            var occupiedBedsResult = await handler.Handle(req, cancellationToken);
            var occupiedBedsIds = occupiedBedsResult?.OccupiedRooms?.Data?.ToArray();
            var allBedsAreAvailable = occupiedBedsIds == null || occupiedBedsIds.Length == 0;

            if (occupiedBedsIds != null)
                foreach (var room in unitCare.Rooms)
                {
                    foreach (var equipment in room.Equipments)
                    {
                        // jump over the other equipments, we search for beds only
                        if (equipment == null || equipment.EqType != EqType.bed) continue;

                        //Now we have only equipments of type BED here

                        //if all beds are available, return this first BED we found
                        if (allBedsAreAvailable)
                        {
                            return equipment;
                        }
                        //if this BED is not in the occupied list of bed => return it
                        else if (occupiedBedsIds.Contains(EquipmentId.Of(equipment.Id)) == false)
                            return equipment;
                        //if didnt yet return, continue searching for next equipment, then next room...
                    }
                }
            return null;
        }
    }
}