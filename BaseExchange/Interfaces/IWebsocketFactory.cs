using System.Collections.Generic;
using BaseExchange.Logging;

namespace BaseExchange.Interfaces
{
    public interface IWebsocketFactory
    {
        IWebsocket CreateWebsocket(Log log, string url);
        IWebsocket CreateWebsocket(Log log, string url, IDictionary<string, string> cookies, IDictionary<string, string> headers);
    }
}
