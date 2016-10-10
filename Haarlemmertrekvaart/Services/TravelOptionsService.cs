using System;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.TravelOptions;

namespace Haarlemmertrekvaart.Services
{
    public class TravelOptionsService
    {
        private readonly NsClient _nsClient;

        public TravelOptionsService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        public async Task<ReisMogelijkheden> GetTravelOptions(string departure, string destination)
        {
            if (string.IsNullOrWhiteSpace(departure))
            {
                throw new ArgumentException("Departure cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("Destination cannot be null or whitespace!");
            }

            return await _nsClient.Get<ReisMogelijkheden>("ns-api-treinplanner?fromStation=Utrecht+Centraal&toStation=Wierden&departure=true");
        }
    }
}
