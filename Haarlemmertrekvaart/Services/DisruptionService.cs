using Haarlemmertrekvaart.Clients;

namespace Haarlemmertrekvaart.Services
{
    public class DisruptionService
    {
        private readonly NsClient _nsClient;

        public DisruptionService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }
    }
}
