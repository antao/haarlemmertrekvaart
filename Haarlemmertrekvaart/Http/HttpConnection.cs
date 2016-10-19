using Haarlemmertrekvaart.Http.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Haarlemmertrekvaart.Http
{
    public class HttpConnection : IHttpConnection
    {
        private static readonly HttpClient HttpClient = new HttpClient(CreateHttpClientHandler());

        public async Task<IHttpResponse> Get(IHttpRequest request)
        {
            ConfigureRequest(request, HttpClient);
            var httpResponseMessage = await HttpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
            return await CreatHttpResponse(httpResponseMessage).ConfigureAwait(false);
        }

        private static async Task<IHttpResponse> CreatHttpResponse(HttpResponseMessage responseMessage)
        {
            var response = new HttpResponse(responseMessage.IsSuccessStatusCode)
            {
                HttpHeaders = GetResponseHeaders(responseMessage.Headers),
                StatusCode = responseMessage.StatusCode,
                ReasonPhrase = responseMessage.ReasonPhrase,
                Content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
            };

            return response;
        }

        private static Dictionary<string, string> GetResponseHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> responseHeaders)
        {
            return responseHeaders.ToDictionary(header => header.Key, header => header.Value.First());
        }

        private static HttpClientHandler CreateHttpClientHandler()
        {
            // Support HttpCompression ? 
            var httpClientHandler = new HttpClientHandler
            {
                // AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };

            return httpClientHandler;
        }

        private static void ConfigureRequest(IHttpRequest request, HttpClient client)
        {
            // ValidateTimeouts(request, client);
            AddHeaders(request.HttpHeaders, client);
        }

        private static void AddHeaders(IEnumerable<KeyValuePair<string, string>> headers, HttpClient client)
        {
            foreach (var keyValuePair in headers)
            {
                switch (keyValuePair.Key.ToLowerInvariant())
                {
                    default:
                        client.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, keyValuePair.Value);
                        continue;
                }
            }
        }
    }
}
