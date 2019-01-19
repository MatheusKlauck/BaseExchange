﻿using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using BaseExchange.Interfaces;
using WebSocket4Net;

namespace BaseExchange.TestImplementations
{
    public class TestSocket : IWebsocket
    {
        public bool CanConnect { get; set; }
        public bool Connected { get; set; }

        public event Action OnClose;
        public event Action<string> OnMessage;
        public event Action<Exception> OnError;
        public event Action OnOpen;

        public int Id { get; }
        public bool ShouldReconnect { get; set; }
        public TimeSpan Timeout { get; set; }
        public Func<byte[], string> DataInterpreter { get; set; }
        public DateTime? DisconnectTime { get; set; }
        public string Url { get; }
        public WebSocketState SocketState { get; }
        public bool IsClosed => !Connected;
        public bool IsOpen => Connected;
        public bool PingConnection { get; set; }
        public TimeSpan PingInterval { get; set; }
        public SslProtocols SSLProtocols { get; set; }

        public int ConnectCalls { get; private set; }
        public bool Reconnecting { get; set; }
        public string Origin { get; set; }

        public static int lastId = 0;
        public static object lastIdLock = new object();

        public TestSocket()
        {
            lock (lastIdLock)
            {
                Id = lastId + 1;
                lastId++;
            }
        }

        public Task<bool> Connect()
        {
            Connected = CanConnect;
            ConnectCalls++;
            return Task.FromResult(CanConnect);
        }

        public void Send(string data)
        {
            if (!Connected)
                throw new Exception("Socket not connected");
        }

        public void Reset()
        {
        }

        public Task Close()
        {
            Connected = false;
            DisconnectTime = DateTime.UtcNow;
            OnClose?.Invoke();
            return Task.FromResult(0);
        }

        public void SetProxy(string host, int port)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
        }

        public void InvokeClose()
        {
            Connected = false;
            DisconnectTime = DateTime.UtcNow;
            OnClose?.Invoke();
        }

        public void InvokeOpen()
        {
            OnOpen?.Invoke();
        }

        public void InvokeMessage(string data)
        {
            OnMessage?.Invoke(data);
        }
    }
}
