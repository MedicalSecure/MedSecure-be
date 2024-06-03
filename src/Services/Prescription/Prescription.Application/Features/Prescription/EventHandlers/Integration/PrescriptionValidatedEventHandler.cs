using BuildingBlocks.Messaging.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.EventHandlers.Integration
{
    public class PrescriptionValidatedEventHandler(ISender sender) : IConsumer<InpatientPrescriptionSharedEvent>
    {
        public Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            Console.WriteLine(context.Message);



            return Task.Delay(5000);
        }
    }
}