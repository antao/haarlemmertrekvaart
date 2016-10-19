using System.Threading.Tasks;
using Haarlemmertrekvaart.Disruption;

namespace Haarlemmertrekvaart.Modules
{
    public class DisruptionModule
    {
        private readonly NsClient _nsClient;

        public DisruptionModule(NsClient nsClient)
        {
            _nsClient = nsClient;
        }

        /// <summary>
        /// Gets all the disruptions and engineering work, planned or unplanned for a given station.
        /// </summary>
        /// <param name="actual">Boolean (true or false) indicator of the current disruptions must be returned. This includes both unscheduled disruptions at the moment of the request, as well as engineering work scheduled to take place within two hours of the request.</param>
        /// <param name="station">The code (abbreviation) or short, medium or full name or synonym for the station name.</param>
        /// <param name="unplanned">Boolean (true or false) indicator of the scheduled engineering work for the next two weeks must be returned. Note: unplanned=true will return the scheduled engineering work. This is therefore the opposite of what the parameter name would imply.</param>
        /// <returns>Storingen</returns>
        public async Task<Storingen> GetAll(bool actual, string station, bool unplanned = false)
        {
            string url = $"ns-api-storingen?actual={actual}&station={station}&unplanned={unplanned}";
            return await _nsClient.Get<Storingen>(url);
        }
    }
}
