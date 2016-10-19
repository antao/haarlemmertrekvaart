using Haarlemmertrekvaart.Http;
using System;
using System.ComponentModel;
using System.Text;

namespace Haarlemmertrekvaart.Configuration
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ConnectionConfiguration
    {
        private const string AcceptKey = "Accept";
        private const string Authorization = "Authorization";
        private const string ContentTypeKey = "Content-Type";
        private const string AcceptCharset = "Accept-Charset";

        public HttpHeaders HttpHeaders { get; private set; }

        public TimeSpan? RequestTimeout { get; set; }

        public TimeSpan? KeepAlive { get; set; }

        public ConnectionConfiguration(string username, string password)
        {
            HttpHeaders = new HttpHeaders();

            // Unfortunatelly only BasicAuthentication is supported by the NS API
            var authorizationHeader = Convert.ToBase64String(new UTF8Encoding().GetBytes($"{username}:{password}"));

            HttpHeaders.AddHeader(Authorization, $"Basic {authorizationHeader}");
            HttpHeaders.AddHeader(AcceptCharset, "UTF-8");
        }
    }
}
