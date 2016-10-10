using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Haarlemmertrekvaart.Services;

namespace Haarlemmertrekvaart.Clients
{
    public class NsClient
    {
        private static readonly Uri ApiUrl = new Uri("https://webservices.ns.nl/");
        private static readonly HttpClient HttpClient = new HttpClient();

        public NsClient(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("The username cannot be null or whitespace!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("The password cannot be null or whitespace!");
            }

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(new ASCIIEncoding().GetBytes($"{username}:{password}")));
        }

        internal async Task<T> Get<T>(string url) where T : new()
        {
            var httpRequest = CreateHttpRequest(url, HttpMethod.Get);
            return await Request<T>(httpRequest);
        }

        internal async Task<T> Post<T>(string url) where T : new()
        {
            throw new NotImplementedException();
        }

        internal async Task<T> Put<T>(string url) where T : new()
        {
            throw new NotImplementedException();
        }

        internal async Task<T> Request<T>(HttpRequestMessage httpRequest) where T : new()
        {
            var response = await HttpClient.SendAsync(httpRequest);

            // todo : support invalid authorization;

            // todo : support rate limits
            //if (response.Headers.Contains("X-"))

            if (response.IsSuccessStatusCode)
            {

                // Deserialize object // todo : what about returning json dear NS friends?!
                var data = await response.Content.ReadAsStreamAsync();
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var streamReader = new StreamReader(data))
                {
                    return (T)xmlSerializer.Deserialize(streamReader.BaseStream);
                }
            }

            return default(T);
        }

        private HttpRequestMessage CreateHttpRequest(string url, HttpMethod httpMethod)
        {
            var finalUrl = ApiUrl + url;

            // todo : validate HTTPS connection

            var httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(finalUrl),
                Method = httpMethod
            };

            return httpRequest;
        }

        /// <summary>
        /// Provides all API methods in Station area
        /// </summary>
        public StationService StationService => new StationService(this);

        /// <summary>
        /// Provides all API methods in Travel Planner area
        /// </summary>
        public TravelOptionsService TravelOptionsService => new TravelOptionsService(this);
    }
}
