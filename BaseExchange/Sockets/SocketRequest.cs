using Newtonsoft.Json;

namespace BaseExchange.Sockets
{
    public class SocketRequest
    {
        [JsonIgnore]
        public bool Signed { get; set; }
    }
}
