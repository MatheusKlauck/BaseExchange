using System.IO;
using System.Net;
using BaseExchange.Interfaces;

namespace BaseExchange.Requests
{
    public class Response : IResponse
    {
        private readonly WebResponse response;

        public Response(WebResponse response)
        {
            this.response = response;
        }

        public Stream GetResponseStream()
        {
            return response.GetResponseStream();
        }

        public void Close()
        {
            response.Close();
        }
    }
}
