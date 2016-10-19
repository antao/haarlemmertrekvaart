using System;
using System.Threading.Tasks;
using Haarlemmertrekvaart.TravelPlanner;

namespace Haarlemmertrekvaart.Modules
{
    public class TravelPlannerModule
    {
        private readonly NsClient _nsClient;

        public TravelPlannerModule(NsClient nsClient)
        {
            _nsClient = nsClient;
        }

        /// <summary>
        /// Can be used to employ the NS Travel planner for a train journey from one station to another. A travel recommendation consists of multiple travel options, 
        /// so that the passenger can make a choice. A travel recommendation includes both planned and up to date information.
        /// </summary>
        /// <param name="fromStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the departure station</param>
        /// <param name="toStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the arrival station</param>
        /// <returns>The response consists of the element JourneyOptions, which contains one JourneyOption element for each journey option.</returns>
        public async Task<ReisMogelijkheden> GetAll(string fromStation, string toStation)
        {
            if (string.IsNullOrWhiteSpace(fromStation))
            {
                throw new ArgumentException("Departure cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(toStation))
            {
                throw new ArgumentException("Destination cannot be null or whitespace!");
            }

            string url = $"ns-api-treinplanner?fromStation={fromStation}&toStation={toStation}";

            return await _nsClient.Get<ReisMogelijkheden>(url);
        }

        ///// <summary>
        ///// Can be used to employ the NS Travel planner for a train journey from one station to another. A travel recommendation consists of multiple travel options, 
        ///// so that the passenger can make a choice. A travel recommendation includes both planned and up to date information.
        ///// </summary>
        ///// <param name="fromStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the departure station</param>
        ///// <param name="toStation">The code (abbreviation) or short name or medium-length name or full name or synonym of the arrival station</param>
        ///// <param name="departure">Boolean (true or false) that indicates whether the dateTime parameters show the desired departure time (=true and the default) or the arrival time (=false)</param>
        ///// <param name="viaStation">Boolean (true or false) that indicates whether the travel recommendations may include high-speed trains. Default is true</param>
        ///// <param name="previousAdvices">The number of recommendations in the past - relative to the departure/arrival time - that is required. There is no guarantee that the response to this will be sufficient; in some cases this number may be higher or lower.</param>
        ///// <param name="nextAdvices">The number of recommendations in the future that is required. There is no guarantee that the response to this will be sufficient; in some cases this number may be higher or lower.</param>
        ///// <param name="dateTime">ISO8601 formatted date that indicates either the desired arrival time or the desired departure time. If not specified then the current date/time is used. E.g. 2012-02-21T15:50.</param>
        ///// <param name="hslAllowed">Boolean (true or false) that indicates whether the travel recommendations may include high-speed trains. Default is true</param>
        ///// <param name="yearCArd">Boolean (true or false) that indicates whether the user has an annual travel card. Sometimes this can result in extra travel recommendations whereby the route extends beyond the final destination, and then goes back again (if this results in a faster journey). These recommendations are not given when yearCard=false, because they would incur additional charges. Default is false</param>
        ///// <returns>The response consists of the element JourneyOptions, which contains one JourneyOption element for each journey option.</returns>
        ////public async Task<ReisMogelijkheden> GetRecommendations(string fromStation, string toStation, string viaStation, string dateTime,
        //      string previousAdvices = "5", string nextAdvices = "5", bool yearCArd = false, bool hslAllowed = false, bool departure = false)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
