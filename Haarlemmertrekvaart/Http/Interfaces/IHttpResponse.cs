using System.Collections.Generic;
using System.Net;

namespace Haarlemmertrekvaart.Http.Interfaces
{
    public interface IHttpResponse
    {
        IDictionary<string, string> HttpHeaders { get; set; }

        HttpStatusCode StatusCode { get; set; }

        bool IsSuccessStatusCode { get; }

        string ReasonPhrase { get; set; }

        string Content { get; set; }
    }
}
