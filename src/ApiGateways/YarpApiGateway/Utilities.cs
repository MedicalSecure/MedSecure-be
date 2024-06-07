namespace YarpApiGateway
{
    public static class Utilities
    {

        public static List<string> GetAddressesFromConfig(IConfiguration configuration)
        {
            var addresses = new List<string>();

            var clustersSection = configuration.GetSection("ReverseProxy:Clusters");
            foreach (var cluster in clustersSection.GetChildren())
            {
                var destinationsSection = cluster.GetSection("Destinations");
                foreach (var destination in destinationsSection.GetChildren())
                {
                    var address = destination.GetValue<string>("Address");
                    addresses.Add(address);
                }
            }

            return addresses;
        }
    }
}
