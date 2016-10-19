using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.Station;
using System;

namespace Haarlemmertrekvaart.Services
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
            return await _nsClient.Get<Stations>(new Uri("https://webservices.ns.nl/ns-api-stations-v2"));
        }
    }
}
