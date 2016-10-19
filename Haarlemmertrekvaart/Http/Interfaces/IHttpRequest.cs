using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Haarlemmertrekvaart.Http.Interfaces
{
    public interface IHttpRequest
    {
        HttpMethod Method { get; set; }

        Uri RequestUri { get; }

        IEnumerable<KeyValuePair<string, string>> HttpHeaders { get; }

        string Content { get; }

        string ContentType { get; }

        TimeSpan? Timeout { get; set; }
    }
}
