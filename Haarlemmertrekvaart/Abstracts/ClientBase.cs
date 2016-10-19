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

        private static readonly Uri endpoint = new Uri("https://webservices.ns.nl/");

        protected ClientBase(ConnectionConfiguration configurationSettings, HttpConnection httpConnection)
        {
            _configurationSettings = configurationSettings;
            _httpConnection = httpConnection ?? new HttpConnection();
        }

        internal async Task<T> Get<T>(Uri uri) where T : new()
        {
            var httpRequest = BuildRequest(uri);
            httpRequest.Method = HttpMethod.Get;

            var httpResponse = await _httpConnection.Get(httpRequest);
            return DeserializeContent<T>(httpResponse.Content);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Post<T>(string url) where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Put<T>(string url) where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<T> Delete<T>(string url) where T : new()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

        private IHttpRequest BuildRequest(Uri requestUri)
        {
            return new HttpRequest(requestUri, _configurationSettings.HttpHeaders, null, null, _configurationSettings.RequestTimeout);
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
