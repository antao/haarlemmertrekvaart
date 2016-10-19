using System.Threading.Tasks;
using Haarlemmertrekvaart.Station;

namespace Haarlemmertrekvaart.Modules
{
    public class StationModule
    {
        private readonly NsClient _nsClient;

        public StationModule(NsClient nsClient)
        {
            _nsClient = nsClient;
        }

        public async Task<Stations> GetAll()
        {
            return await _nsClient.Get<Stations>("ns-api-stations-v2");
        }
    }
}
