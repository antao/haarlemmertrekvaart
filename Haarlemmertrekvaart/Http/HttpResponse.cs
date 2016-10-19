using Haarlemmertrekvaart.Http.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace Haarlemmertrekvaart.Http
{
    public class HttpResponse : IHttpResponse
    {
        public IDictionary<string, string> HttpHeaders { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccessStatusCode { get; private set; }

        public string ReasonPhrase { get; set; }

        public string Content { get; set; }

        public HttpResponse(bool isSuccess)
        {
            IsSuccessStatusCode = isSuccess;
        }
    }
}
