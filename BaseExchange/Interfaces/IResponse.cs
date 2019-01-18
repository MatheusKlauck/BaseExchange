using System.IO;

namespace BaseExchange.Interfaces
{
    public interface IResponse
    {
        Stream GetResponseStream();
        void Close();
    }
}
