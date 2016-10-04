using System;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.TravelPlanner;

namespace Haarlemmertrekvaart.Services
{
    public class TravelPlannerService
    {
        private readonly NsClient _nsClient;

        public TravelPlannerService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        public async Task<ReisMogelijkheden> Planner(string departure, string destination)
        {
            if (string.IsNullOrWhiteSpace(departure))
            {
                throw new ArgumentException("Departure cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("Destination cannot be null or whitespace!");
            }

            return await _nsClient.Get<ReisMogelijkheden>("ns-api-treinplanner?fromStation=Amsterdam+Centraal&toStation=Rotterdam+Centraal&departure=true");
        }
    }
}
