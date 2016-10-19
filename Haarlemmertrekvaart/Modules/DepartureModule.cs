using System;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Departure;

namespace Haarlemmertrekvaart.Modules
{
    public class DepartureModule
    {
        private readonly NsClient _nsClient;

        public DepartureModule(NsClient nsClient)
        {
            _nsClient = nsClient;
        }

        /// <summary>
        /// Up to date departure times allows users to request an up to date overview for a station which shows all departing trains for the next hour.
        /// </summary>
        /// <param name="station">The code (abbreviation) or short name or medium-length name or full name or synonym of the station's name</param>
        /// <returns>ActueleVertrekTijden</returns>
        public async Task<ActueleVertrekTijden> GetAll(string station)
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
