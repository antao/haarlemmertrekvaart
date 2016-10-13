using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.Station;

namespace Haarlemmertrekvaart.Services
{
    public class StationService
    {
        private readonly NsClient _nsClient;

        public StationService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        public async Task<Stations> GetStations()
        {
            return await _nsClient.Get<Stations>("ns-api-stations-v2");
        }
    }
}
