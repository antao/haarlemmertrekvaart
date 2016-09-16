using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.Station;

namespace Haarlemmertrekvaart.Services
{
    public interface IStationService
    {
        Task<Stations> GetStationsAsync();
    }

    public class StationService
    {
        private readonly NsClient _nsClient;

        public StationService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        public async Task<Stations> GetStationsAsync()
        {
            return await _nsClient.Get<Stations>("ns-api-stations-v2");
        }
    }
}
