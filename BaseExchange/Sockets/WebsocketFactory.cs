using System.Collections.Generic;
using BaseExchange.Interfaces;
using BaseExchange.Logging;

namespace BaseExchange.Sockets
{
    public class WebsocketFactory : IWebsocketFactory
    {
        public IWebsocket CreateWebsocket(Log log, string url)
        {
            return new BaseSocket(log, url);
        }

        public IWebsocket CreateWebsocket(Log log, string url, IDictionary<string, string> cookies, IDictionary<string, string> headers)
        {
            return new BaseSocket(log, url, cookies, headers);
        }
    }
}
