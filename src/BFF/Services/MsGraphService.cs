using Azure.Identity;
using Microsoft.Graph;

namespace BffMicrosoftEntraID.Server.Services
{
    public class MsGraphService
    {
        private readonly GraphServiceClient _graphServiceClient;

        public MsGraphService(IConfiguration configuration)
        {
            // Obtain the necessary configuration values
            var clientId = configuration.GetValue<string>("MicrosoftEntraID:ClientId");
            var clientSecret = configuration.GetValue<string>("MicrosoftEntraID:ClientSecret");
            var tenantId = configuration.GetValue<string>("MicrosoftEntraID:TenantId");

            // Create a client secret credential for Azure Identity
            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, 
                                    new TokenCredentialOptions { AuthorityHost = AzureAuthorityHosts.AzurePublicCloud });

            string[] defaultScopes = { "https://graph.microsoft.com/.default" };

            // Create GraphServiceClient with Azure Identity
            _graphServiceClient = new GraphServiceClient(clientSecretCredential, defaultScopes);
        }

        public GraphServiceClient GetGraphServiceClient()
        {
            return _graphServiceClient;
        }
    }
}
