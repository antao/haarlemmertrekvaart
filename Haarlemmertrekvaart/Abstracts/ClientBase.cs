using Haarlemmertrekvaart.Configuration;
using Haarlemmertrekvaart.Http;
using Haarlemmertrekvaart.Http.Interfaces;
using Haarlemmertrekvaart.Serializers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Haarlemmertrekvaart.Http.Exceptions;

namespace Haarlemmertrekvaart.Abstracts
{
    public abstract class ClientBase
    {
        private readonly ConnectionConfiguration _configurationSettings;
        private readonly HttpConnection _httpConnection;
        private readonly ISerializer _serializer;

        private static readonly Uri Endpoint = new Uri("https://webservices.ns.nl/");

        protected ClientBase(ConnectionConfiguration configurationSettings, HttpConnection httpConnection, ISerializer serializer)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException(nameof(configurationSettings));
            }

            _configurationSettings = configurationSettings;
            _httpConnection = httpConnection ?? new HttpConnection();
            _serializer = serializer ?? new XmlSerializer();
        }

        internal async Task<T> Get<T>(string url) where T : new()
        {
            var httpRequest = CreateHttpRequest(url, HttpMethod.Get);
            var httpResponse = await _httpConnection.Get(httpRequest).ConfigureAwait(false);
            ValidateResponse(httpResponse);
            return _serializer.Deserialize<T>(httpResponse.Content);
        }

        private static void ValidateResponse(IHttpResponse response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException(response.StatusCode);
            }
        }

        private IHttpRequest CreateHttpRequest(string requestUrl, HttpMethod httpMethod)
        {
            return new HttpRequest(new Uri(Endpoint + requestUrl), _configurationSettings.HttpHeaders, httpMethod, null, null, _configurationSettings.RequestTimeout);
        }
    }
}