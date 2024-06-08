using BuildingBlocks.Exceptions;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Messaging.Events.Drugs;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus;
using Prescription.Application.Hubs;
using Prescription.Application.Hubs.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.EventHandlers.Integration
{
    public class PrescriptionValidationEventHandler(ISender sender, IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IPrescriptionHub prescriptionHub) : IConsumer<PrescriptionValidationSharedEvent>
    {
        public async Task Consume(ConsumeContext<PrescriptionValidationSharedEvent> context)
        {
            try
            {
                var response = context.Message;
                var isRejected = response.Validated == false;
                var getByIdQuery = new GetPrescriptionByIdQuery(response.PrescriptionId);
                var byIdResponse = await sender.Send(getByIdQuery);
                var prescription = (byIdResponse?.Prescriptions.Data.FirstOrDefault()) ?? throw new NotFoundException($"Cant find a prescription with the id {getByIdQuery}");

                var newPrescription = prescription with { Status = isRejected ? PrescriptionStatus.Rejected : PrescriptionStatus.Active };

                string activityMessage = string.Empty;
                if (isRejected == false)
                {
                    //Active prescription
                    var eventMessage = newPrescription.Adapt<ValidatedPrescriptionSharedEvent>();
                    //fill the unitCare from the request, cuz we save only the bed id in the DB
                    eventMessage.UnitCare = JsonConvert.DeserializeObject<UnitCarePlanSharedEvent>(response.UnitCareJson) ?? throw new NotFoundException($"Cant deserialize UnitCare From event for prescription : {getByIdQuery}"); ;
                    eventMessage.PharmacistId = response.PharmacistId;
                    eventMessage.Remarques = response.Notes ?? string.Empty;
                    eventMessage.PharmacistName = response.PharmacistName ?? string.Empty;
                    // for testing purposes  TODO REMOVE
                    var ValidInpatientShared = JsonConvert.SerializeObject(eventMessage);

                    await publishEndpoint.Publish(eventMessage);

                    //Update local validation
                    var PrescriptionTracked = dbContext.Prescriptions.FirstOrDefault(p => p.Id == PrescriptionId.Of(response.PrescriptionId));
                    if (PrescriptionTracked == null)
                        throw new NotFoundException($"Cant find prescription with id {response.PrescriptionId}");

                    var validation = Validation.CreateValidated(PrescriptionTracked.Id, response.PharmacistId, response.Notes, response.PharmacistName);
                    //will throw an error if its invalid operation
                    PrescriptionTracked.AddValidation(validation);
                    dbContext.Prescriptions.Update(PrescriptionTracked);
                    await dbContext.SaveChangesAsync(CancellationToken.None);

                    //Create activity message
                    activityMessage = $"Received a prescription validation";
                }
                else
                {
                    //Rejected prescription
                    //No event to send currently => just add local validation
                    //Update local validation
                    var PrescriptionTracked = dbContext.Prescriptions.FirstOrDefault(p => p.Id == PrescriptionId.Of(response.PrescriptionId));
                    if (PrescriptionTracked == null)
                        throw new NotFoundException($"Cant find prescription with id {response.PrescriptionId}");

                    var validation = Validation.CreateRejected(PrescriptionTracked.Id, response.PharmacistId, response.Notes ?? "No notes were given", response.PharmacistName);
                    //will throw an error if its invalid operation
                    PrescriptionTracked.AddValidation(validation);
                    dbContext.Prescriptions.Update(PrescriptionTracked);
                    await dbContext.SaveChangesAsync(CancellationToken.None);

                    await prescriptionHub.SendEventToAll(response);

                    //Create activity message
                    activityMessage = $"Received a prescription rejection";
                }

                //Create activity
                var activityToAdd = Domain.Entities.Activity.Create(response.PharmacistId, activityMessage, "Hammadi AZ");
                dbContext.Activities.Add(activityToAdd);
                await dbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception x)
            {
                Console.WriteLine(x);//TODO => move to logs
                //Continue => don't break the application
            }
        }
    }
}