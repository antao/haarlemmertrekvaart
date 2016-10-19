using Haarlemmertrekvaart.Abstracts;
using Haarlemmertrekvaart.Configuration;
using Haarlemmertrekvaart.Http;
using Haarlemmertrekvaart.Modules;

namespace Haarlemmertrekvaart
{
    public class NsClient : ClientBase
    {
        public NsClient(ConnectionConfiguration configurationSettings, HttpConnection httpConnection = null) : base(configurationSettings, httpConnection)
        {
        }

        /// <summary>
        /// Provides all API methods in Station area
        /// </summary>
        public StationModule Stations => new StationModule(this);

        //// <summary>
        ///// Provides all API methods in Travel Planner area
        ///// </summary>
        //public TravelPlannerService TravelPlannerService => new TravelPlannerService(this);

        ///// <summary>
        ///// Provides all API methods in Disruption/Engineering works area
        ///// </summary>
        //public DisruptionService DisruptionService => new DisruptionService(this);

        ///// <summary>
        ///// Provides all API methods in Departure area
        ///// </summary>
        //public DepartureModule Departure => new DepartureModule(this);
    }
}
