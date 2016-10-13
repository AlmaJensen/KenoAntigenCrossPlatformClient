using KenoAntigen.Interfaces;
using KenoAntigen.Messages;
using KenoAntigen.Utils;
using KenoAntigenWrapper;
using KenoAntigenWrapper.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websockets;

namespace KenoAntigen.Services
{
    public class SocketService : ISocketService
    {
        public bool IsConnected { get; set; }
        public string ClientCode { get; set; }
        public string DefaultConnectionString { get; set; } = "ws://139.162.238.60:8090/ws/user";

        IWebSocketConnection connection;

        public SocketService(string url = "ws://139.162.238.60:8090/ws/user")
        {
            InitEvents();

            OpenConnection(url);

            
        }

        private void AuthenticateWithServer(string url)
        {
            var initCodeRequest = new ClientCode();
            SendRequest(initCodeRequest);
        }

        private void InitEvents()
        {
            connection = Websockets.WebSocketFactory.Create();
            connection.OnClosed += Connection_OnClosed;
            connection.OnDispose += Connection_OnDispose;
            connection.OnError += Connection_OnError;
            connection.OnLog += Connection_OnLog;
            connection.OnMessage += Connection_OnMessage;
            connection.OnOpened += Connection_OnOpened;
        }

        public async void OpenConnection(string url)
        {
            connection.Open(url);
            while (!connection.IsOpen)
            {
                await Task.Delay(10);
            }
            AuthenticateWithServer(url);
        }

        private void Connection_OnOpened()
        {
            IsConnected = true;
        }

        private void Connection_OnMessage(string obj)
        {
            var message = DeSerializer.DeSerialize(obj);
            ConsoleDebugWriter.OutputObjectToConsole(obj, "Message from server");
            if (string.IsNullOrEmpty(ClientCode))
            {
                ClientCode = message?.content?.clientCode;
            }
            else
                new MessageReceivedMessage(message);
        }

        private void Connection_OnLog(string obj)
        {
            
        }

        private void Connection_OnError(string obj)
        {
            IsConnected = false;
        }

        private void Connection_OnDispose(IWebSocketConnection obj)
        {
            IsConnected = false;
        }

        private void Connection_OnClosed() =>        
            IsConnected = false;
        
        public void SendRequest(BaseRequest request) =>
            connection.Send(Serializer.SerializeObject(request));
    }
}
