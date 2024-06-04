using BuildingBlocks.Exceptions;
using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Messaging.Events.Drugs;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.EventHandlers.Integration
{
    public class PrescriptionValidationEventHandler(ISender sender, IPublishEndpoint publishEndpoint) : IConsumer<PrescriptionValidationSharedEvent>
    {
        public async Task Consume(ConsumeContext<PrescriptionValidationSharedEvent> context)
        {
            var response = context.Message;
            var isRejected = response.Validated == false;
            var getByIdQuery = new GetPrescriptionByIdQuery(response.PrescriptionId);
            var byIdResponse = await sender.Send(getByIdQuery);
            var prescription = (byIdResponse?.Prescriptions.Data.FirstOrDefault()) ?? throw new NotFoundException($"Cant find a prescription with the id {getByIdQuery}");

            var newPrescription = prescription with { Status = isRejected ? PrescriptionStatus.Rejected : PrescriptionStatus.Active };

            var command = new UpdatePrescriptionStatusCommand(newPrescription);
            var updateResult = await sender.Send(command);
            Console.WriteLine($" Status Updated  {updateResult.Id}");
            if (isRejected == false)
            {
                //Active prescription
                var eventMessage = newPrescription.Adapt<ValidatedPrescriptionSharedEvent>();
                //fill the unitCare from the request, cuz we save only the bed id in the DB
                eventMessage.UnitCare = JsonConvert.DeserializeObject<UnitCarePlanSharedEvent>(response.UnitCareJson) ?? throw new NotFoundException($"Cant deserialize UnitCare From event for prescription : {getByIdQuery}"); ;
                eventMessage.PharmacistId = response.PharmacistId;
                eventMessage.Remarques = response.Remarques ?? string.Empty;
                eventMessage.PharmacistName = response.PharmacistName ?? string.Empty;
                var ValidInpatientShared = JsonConvert.SerializeObject(eventMessage);
                await publishEndpoint.Publish(eventMessage);
            }
        }
    }
}