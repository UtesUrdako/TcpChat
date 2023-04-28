using System;

namespace ChatClient.Interface
{
    public interface IChatClientModel
    {
        event Action onConnect;
        event Action onDisconnect;
        event Action<string> onReceiveMessage;

        void Connect(string host, int port, string userName);
        void Disconnect();
        void SendMessage(string message);
    }
}
