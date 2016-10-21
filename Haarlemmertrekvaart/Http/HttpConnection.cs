using Haarlemmertrekvaart.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Haarlemmertrekvaart.Http
{
    public class HttpConnection : IHttpConnection
    {
        private static readonly HttpClient HttpClient = new HttpClient(CreateHttpClientHandler());

        public async Task<IHttpResponse> Get(IHttpRequest request)
        {
            IHttpResponse httpResponse;
            ConfigureRequest(request, HttpClient);
            try
            {
                var httpResponseMessage = await HttpClient.GetAsync(request.RequestUri).ConfigureAwait(false);
                httpResponse = await CreatHttpResponse(httpResponseMessage).ConfigureAwait(false);
            }
            catch (WebException ex)
            {
                httpResponse = HandleException(ex);
            }

            return httpResponse;
        }

        public Task<IHttpResponse> Put(IHttpRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpResponse> Post(IHttpRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpResponse> Delete(IHttpRequest request)
        {
            throw new NotImplementedException();
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
            var httpClientHandler = new HttpClientHandler
            {
                // Support HttpCompression ? 
                // AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };

            return httpClientHandler;
        }

        private static void ConfigureRequest(IHttpRequest request, HttpClient client)
        {
            SetTimeout(request, client);
            AddHeaders(request.HttpHeaders, client);
        }

        private static void SetTimeout(IHttpRequest request, HttpClient client)
        {
            if (!request.Timeout.HasValue)
                return;

            client.Timeout = request.Timeout.Value;
        }

        private static void AddHeaders(IEnumerable<KeyValuePair<string, string>> headers, HttpClient client)
        {
            foreach (var keyValuePair in headers)
            {
                if (client.DefaultRequestHeaders.Contains(keyValuePair.Key))
                    return; 

                switch (keyValuePair.Key.ToLowerInvariant())
                {
                    default:
                        client.DefaultRequestHeaders.TryAddWithoutValidation(keyValuePair.Key, keyValuePair.Value);
                        continue;
                }
            }
        }

        private static IHttpResponse HandleException(Exception e)
        {
            return new HttpResponse(false)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ReasonPhrase = "Internal Server Error",
                Content = e.Message
            };
        }
    }
}
