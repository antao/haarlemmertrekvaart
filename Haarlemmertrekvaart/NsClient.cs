using System.Reflection;
using Haarlemmertrekvaart.Abstracts;
using Haarlemmertrekvaart.Configuration;
using Haarlemmertrekvaart.Http;
using Haarlemmertrekvaart.Modules;
using Haarlemmertrekvaart.Serializers;

namespace Haarlemmertrekvaart
{
    public class NsClient : ClientBase
    {
        public NsClient(ConnectionConfiguration configurationSettings, HttpConnection httpConnection = null, ISerializer serializer = null) : base(configurationSettings, httpConnection, serializer)
        {
        }

        /// <summary>
        /// Provides all API methods in Stations area
        /// </summary>
        public StationModule Stations => new StationModule(this);

        /// <summary>
        /// Provides all API methods in Travel Planner area
        /// </summary>
        public TravelPlannerModule TravelPlanner => new TravelPlannerModule(this);

        /// <summary>
        /// Provides all API methods in Disruption/Engineering works area
        /// </summary>
        public DisruptionModule Disruptions => new DisruptionModule(this);

        /// <summary>
        /// Provides all API methods in Departures area
        /// </summary>
        public DepartureModule Departures => new DepartureModule(this);

        /// <summary>
        /// Returns the framework version of the haarlemmertrekvaart.
        /// </summary>
        /// <returns>The version number of the haarlemmertrekvaart.</returns>
        public override string ToString()
        {
            return $"haarlemmertrekvaart version {Assembly.GetExecutingAssembly().GetName().Version}";
        }
    }
}
