﻿using BuildingBlocks.Messaging.Events;
using Newtonsoft.Json;
using Prescription.Application.Exceptions;
using Prescription.Application.Features.UnitCare.Queries;

namespace Prescription.Application.Features.Prescription.Commands.CreatePrescription
{
    public class CreatePrescriptionHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint, IFeatureManager featureManager)
        : ICommandHandler<CreatePrescriptionCommand, CreatePrescriptionResult>
    {
        public async Task<CreatePrescriptionResult> Handle(CreatePrescriptionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Create Prescription entity from command object
                var prescription = await CreateNewPrescription(command.Prescription, cancellationToken);
                // Save to database
                dbContext.Prescriptions.Add(prescription);

                Guid createdBy = Guid.NewGuid();
                var newActivity = Domain.Entities.Activity.Create(createdBy, $"Created new {nameof(Prescription)}", "Hammadi AZ");
                dbContext.Activities.Add(newActivity);

                await dbContext.SaveChangesAsync(cancellationToken);

                // Handle sending events
                var ShareOutPatient = await featureManager.IsEnabledAsync("OutPrescriptionCreated");
                var ShareInPatient = await featureManager.IsEnabledAsync("InpatientPrescriptionCreated");
                // Check if the feature for using message broker is enabled for inpatientPrescription && the prescription is Inpatient
                if (command.Prescription.UnitCare != null && ShareInPatient)
                {
                    var newlyCreatedPrescription = prescription.ToPrescriptionDto(); //use the new one to retrieve the new created IDs with the entities
                    var eventMessage = newlyCreatedPrescription.Adapt<InpatientPrescriptionSharedEvent>();
                    //fill the unitCare from the request, cuz we save only the bed id in the DB
                    eventMessage.UnitCare = command.Prescription.UnitCare.Adapt<UnitCarePlanSharedEvent>();

                    var jsonInpatientShared = JsonConvert.SerializeObject(eventMessage);
                    await publishEndpoint.Publish(eventMessage, cancellationToken);
                }
                // Check if the feature for using message broker is enabled for OutpatientPrescription && the prescription is Outpatient
                else if (command.Prescription.UnitCare == null && ShareOutPatient)
                {
                    //use the new Prescription to retrieve the new created IDs with the entities
                    var newlyCreatedPrescription = prescription.ToPrescriptionDto();
                    var eventMessage = newlyCreatedPrescription.Adapt<OutpatientPrescriptionSharedEvent>();
                    await publishEndpoint.Publish(eventMessage, cancellationToken);
                }

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

        private async Task<Domain.Entities.Prescription> CreateNewPrescription(PrescriptionCreateUpdateDto prescriptionDto, CancellationToken cancellationToken)
        {
            EquipmentDTO? bed = null;
            var diet = prescriptionDto.Diet ?? null;

            if (prescriptionDto.UnitCare != null)
            {
                bed = await GetAvailableRoomFromUnitCare(prescriptionDto.UnitCare, cancellationToken);
                //only if a unitCare has been selected, throw this error, if unitCare is null => Not hospitalized patient
                if (bed == null)
                    throw new Exception($"Cant find empty Bed in UnitCare : {prescriptionDto.UnitCare.Title}");
                //return null;
            }
            if (diet == null && bed != null)
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
                    bedId: EquipmentId.OfNullable(bed?.Id),
                    diet: newDiet
                );

            string createdBy_DoctorId = newPrescription.CreatedBy!;

            var diagnosisEntities = prescriptionDto.Diagnoses
                .Select(dto =>
                {
                    var diagnosis = dbContext.Diagnosis.Find(DiagnosisId.Of(dto.Id));
                    if (diagnosis != null)
                    {
                        dbContext.AttachEntity(diagnosis);
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
                    var symptom = dbContext.Symptoms.Find(SymptomId.Of(dto.Id));
                    if (symptom != null)
                    {
                        dbContext.AttachEntity(symptom);
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
                var newPosology = Domain.Entities.Posology.Create(
                    prescriptionId: newPrescription.Id,
                    medication: await CreateMedication(posology.Medication, dbContext, cancellationToken),
                    startDate: posology.StartDate,
                    endDate: posology.EndDate,
                    isPermanent: posology.IsPermanent,
                    createdBy: createdBy_DoctorId);

                foreach (var comment in posology.Comments)
                {
                    var newComment = Domain.Entities.Comment.Create(
                        posologyId: newPosology.Id,
                        label: comment.Label,
                        content: comment.Content,
                        createdBy: createdBy_DoctorId);

                    newPosology.AddComment(newComment);
                }

                foreach (var dispense in posology.Dispenses)
                {
                    var newDispense = Domain.Entities.Dispense.Create(
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

        private async Task<EquipmentDTO?> GetAvailableRoomFromUnitCare(UnitCareDTO unitCare, CancellationToken cancellationToken)
        {
            var handler = new GetOccupiedBedsHandler(dbContext);

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

        private async Task<Domain.Entities.Medication> CreateMedication(MedicationDTO? medic, IApplicationDbContext dbContext, CancellationToken cancellationToken)
        {
            if (medic == null)
                throw new ArgumentNullException("Medication must be provided");

            var medication = await dbContext.Medications.Where(p => p.Id == MedicationId.Of(medic.Id))
                   .FirstOrDefaultAsync(cancellationToken);

            if (medication != null)
                return medication;

            return Domain.Entities.Medication.Create(
                id: MedicationId.Of(medic.Id),
                name: medic.Name,
                dosage: medic.Dosage,
                form: medic.Form,
                unit: medic.Unit,
                description: medic.Description,
                code: medic.Code,
                expiredAt: medic.ExpiredAt,
                stock: medic.Stock,
                alertStock: medic.AlertStock,
                avrgStock: medic.AvrgStock,
                minStock: medic.MinStock,
                safetyStock: medic.SafetyStock,
                reservedStock: medic.ReservedStock,
                price: medic.Price);
        }
    }
}