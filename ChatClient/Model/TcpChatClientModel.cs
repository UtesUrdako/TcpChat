using ChatClient.Interface;
using System;

namespace ChatClient.Model
{
    internal class TcpChatClientModel : IChatClientModel
    {
        public event Action onConnect;
        public event Action onDisconnect;
        public event Action<string> onReceiveMessage;

        public void Connect(string host, int port, string userName)
        {
            TcpChatClient.TcpChatClient.onConnect += onConnect;
            TcpChatClient.TcpChatClient.onDisconnect += onDisconnect;
            TcpChatClient.TcpChatClient.onReceiveMessage += onReceiveMessage;

            TcpChatClient.TcpChatClient.Connect(host, port, userName);
        }

        public void Disconnect()
        {
            TcpChatClient.TcpChatClient.Disconnect();

            TcpChatClient.TcpChatClient.onConnect -= onConnect;
            TcpChatClient.TcpChatClient.onDisconnect -= onDisconnect;
            TcpChatClient.TcpChatClient.onReceiveMessage -= onReceiveMessage;
        }

        public void SendMessage(string message)
        {
            TcpChatClient.TcpChatClient.SendMessage(message);
        }
    }
}
