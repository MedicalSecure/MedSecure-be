using Microsoft.AspNetCore.Builder;

namespace Prescription.Application.Hubs
{
    public static class HubDependencyInjection
    {
        public static void InjectHubs(this WebApplication app)
        {
            if (app == null)
                throw new ArgumentNullException("WebApplication App is null");

            //Add hubs below
            app.MapHub<PrescriptionHub>("/doctors");
        }
    }
}