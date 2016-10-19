using Haarlemmertrekvaart.Http.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Haarlemmertrekvaart.Http
{
    public class HttpConnection : IHttpConnection
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<IHttpResponse> Get(IHttpRequest request)
        {
            ConfigureRequest(request, HttpClient);
            var responseMessage = await HttpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
            return await BuildResponse(responseMessage).ConfigureAwait(false);
        }

        private static async Task<IHttpResponse> BuildResponse(HttpResponseMessage responseMessage)
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
