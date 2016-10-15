using System.Threading.Tasks;
using Haarlemmertrekvaart.Departure;
using Haarlemmertrekvaart.Clients;
using System;

namespace Haarlemmertrekvaart.Services
{
    public class DepartureService
    {
        private readonly NsClient _nsClient;

        public DepartureService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        public async Task<ActueleVertrekTijden> GetDepartures(string station)
        {
            if (string.IsNullOrWhiteSpace(station))
            {
                throw new ArgumentException("station cannot be null or whitespace!");
            }

            string url = $"ns-api-avt?station={station}";
            return await _nsClient.Get<ActueleVertrekTijden>(url);
        }
    }
}
