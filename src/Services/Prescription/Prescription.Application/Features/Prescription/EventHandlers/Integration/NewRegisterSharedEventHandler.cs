using BuildingBlocks.Exceptions;
using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Messaging.Events.RegistrationEvents;
using Prescription.Application.Hubs.Abstractions;
using MediatR;

namespace Prescription.Application.Features.Prescription.EventHandlers.Integration
{
    public class NewRegisterSharedEventHandler(IPrescriptionHub prescriptionHub) : IConsumer<NewRegisterSharedEvent>
    {
        public async Task Consume(ConsumeContext<NewRegisterSharedEvent> context)
        {
            try
            {
                var response = context.Message;
                await prescriptionHub.SendNewRegisterEventToAll(response);
            }
            catch (Exception x)
            {
                Console.WriteLine(x);//TODO => move to logs
                //Continue => don't break the application
            }
        }
    }
}
