using Haarlemmertrekvaart.Configuration;
using Haarlemmertrekvaart.Http;
using Haarlemmertrekvaart.Http.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Haarlemmertrekvaart.Abstracts
{
    public abstract class ClientBase
    {
        private readonly ConnectionConfiguration _configurationSettings;
        private readonly HttpConnection _httpConnection;
        // todo : inject a serializer private readonly ISerializer _serializer;

        private static readonly Uri Endpoint = new Uri("https://webservices.ns.nl/");

        protected ClientBase(ConnectionConfiguration configurationSettings, HttpConnection httpConnection)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException(nameof(configurationSettings));
            }

            _configurationSettings = configurationSettings;
            _httpConnection = httpConnection ?? new HttpConnection();
        }

        internal async Task<T> Get<T>(string url) where T : new()
        {
            var httpRequest = CreateHttpRequest(url, HttpMethod.Get);
            var httpResponse = await _httpConnection.Get(httpRequest);
            return DeserializeContent<T>(httpResponse.Content);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Post<T>() where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Put<T>() where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Delete<T>() where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

        private IHttpRequest CreateHttpRequest(string requestUrl, HttpMethod httpMethod)
        {
            return new HttpRequest(new Uri(Endpoint + requestUrl), _configurationSettings.HttpHeaders, httpMethod, null, null, _configurationSettings.RequestTimeout);
        }

        private T DeserializeContent<T>(string response)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(response))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }
}