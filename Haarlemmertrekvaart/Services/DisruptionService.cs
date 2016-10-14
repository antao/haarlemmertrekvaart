using System.Threading.Tasks;
using Haarlemmertrekvaart.Clients;
using Haarlemmertrekvaart.Disruption;

namespace Haarlemmertrekvaart.Services
{
    public class DisruptionService
    {
        private readonly NsClient _nsClient;

        public DisruptionService(NsClient currentInstance)
        {
            _nsClient = currentInstance;
        }

        /// <summary>
        /// The webservice for disruptions and engineering work allows you to request information about disruptions and/or engineering work.
        /// </summary>
        /// <param name="actual">Boolean (true or false) indicator of the current disruptions must be returned. This includes both unscheduled disruptions at the moment of the request, as well as engineering work scheduled to take place within two hours of the request.</param>
        /// <param name="station">The code (abbreviation) or short, medium or full name or synonym for the station name.</param>
        /// <param name="unplanned">Boolean (true or false) indicator of the scheduled engineering work for the next two weeks must be returned. Note: unplanned=true will return the scheduled engineering work. This is therefore the opposite of what the parameter name would imply.</param>
        /// <returns>Storingen</returns>
        public async Task<Storingen> GetDisruptions(bool actual, string station, bool unplanned = false)
        {
            string url = $"ns-api-storingen?actual={actual}&station={station}&unplanned={unplanned}";
            return await _nsClient.Get<Storingen>(url);
        }
    }
}
