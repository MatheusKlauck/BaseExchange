using System.Net;
using BaseExchange.Interfaces;

namespace BaseExchange.Requests
{
    public class RequestFactory : IRequestFactory
    {
        public IRequest Create(string uri)
        {
            return new Request(WebRequest.Create(uri));
        }
    }
}
