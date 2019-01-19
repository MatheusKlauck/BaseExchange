using System;
using BaseExchange.Interfaces;
using BaseExchange.Logging;
using BaseExchange.Objects;
using BaseExchange.Sockets;
using BaseExchange.TestImplementations;
using Moq;

namespace BaseExchange.TestImplementations
{
    public class TestSocketClient : SocketClient
    {
        public Func<bool> OnReconnect { get; set; }

        public TestSocketClient() : this(new SocketClientOptions())
        {
        }

        public TestSocketClient(SocketClientOptions exchangeOptions) : base(exchangeOptions, exchangeOptions.ApiCredentials == null ? null : new TestAuthProvider(exchangeOptions.ApiCredentials))
        {
            SocketFactory = new Mock<IWebsocketFactory>().Object;
            Mock.Get(SocketFactory).Setup(f => f.CreateWebsocket(It.IsAny<Log>(), It.IsAny<string>())).Returns(new TestSocket());
        }

        public TestSocket CreateSocket()
        {
            Mock.Get(SocketFactory).Setup(f => f.CreateWebsocket(It.IsAny<Log>(), It.IsAny<string>())).Returns(new TestSocket());
            return (TestSocket)CreateSocket(BaseAddress);
        }

        public CallResult<bool> ConnectSocketSub(SocketSubscription sub)
        {
            return ConnectSocket(sub).Result;
        }

        protected override bool SocketReconnect(SocketSubscription subscription, TimeSpan disconnectedTime)
        {
            return OnReconnect.Invoke();
        }
    }
}
