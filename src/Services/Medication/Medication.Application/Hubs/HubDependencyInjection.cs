using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Hubs
{
    public static class HubDependencyInjection
    {
        public static void InjectHubs(this WebApplication app)
        {
            if (app == null)
                throw new ArgumentNullException("WebApplication App is null");

            //Add hubs below
            app.MapHub<PharmaLinkHub>("/pharmacist");
        }
    }
}