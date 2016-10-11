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

        /// <summary>
        /// Can be used to employ the NS Travel planner for a train journey from one station to another. A travel recommendation consists of multiple travel options, 
        /// so that the passenger can make a choice. A travel recommendation includes both planned and up to date information.
        /// </summary>
        /// <param name="fromStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the departure station</param>
        /// <param name="toStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the arrival station</param>
        /// <param name="departure">Indicates whether the dateTime parameters show the desired departure time (=true and the default) or the arrival time (=false)</param>
        /// <returns></returns>
        public async Task<ReisMogelijkheden> GetRecommendations(string fromStation, string toStation, bool departure)
        {
            if (string.IsNullOrWhiteSpace(fromStation))
            {
                throw new ArgumentException("Departure cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(toStation))
            {
                throw new ArgumentException("Destination cannot be null or whitespace!");
            }

            return await _nsClient.Get<ReisMogelijkheden>("ns-api-treinplanner?fromStation=" + fromStation + "&toStation=" + toStation + "&departure= " + departure + "");
        }
    }
}
