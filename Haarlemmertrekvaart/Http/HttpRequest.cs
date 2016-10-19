using Haarlemmertrekvaart.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Haarlemmertrekvaart.Http
{
    public class HttpRequest : IHttpRequest
    {
        public HttpMethod Method { get; set; }

        public Uri RequestUri { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> HttpHeaders { get; private set; }

        public string Content { get; private set; }

        public string ContentType { get; private set; }

        public TimeSpan? Timeout { get; set; }

        public HttpRequest(Uri requestUri, IEnumerable<KeyValuePair<string, string>> httpHeaders, string content = null, string contentType = null, TimeSpan? timeout = null)
        {
            RequestUri = requestUri;
            HttpHeaders = httpHeaders;
            Content = content;
            ContentType = contentType;
            Timeout = timeout;
        }
    }
}
