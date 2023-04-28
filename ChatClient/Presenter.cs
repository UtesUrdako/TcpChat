using ChatClient.Interface;

namespace ChatClient
{
    public class Presenter
    {
        private MainWindow mainWindow;
        private IChatClientModel chatClient;
        private bool isConnected;

        public Presenter(MainWindow mainWindow, IChatClientModel chatClient)
        {
            this.mainWindow = mainWindow;
            this.chatClient = chatClient;

            chatClient.onConnect += OnConnect;
            chatClient.onDisconnect += OnDisconnect;
            chatClient.onReceiveMessage += OnReceiveMessage;
        }

        public void Connect(string host, int port, string userName)
        {
            chatClient.Connect(host, port, userName);
        }

        public void SendMessage(string message)
        {
            chatClient.SendMessage(message);
            mainWindow.AddMassage($"{mainWindow.UserName}: {message}");
            mainWindow.CleanSendMessage();
        }

        public void Disconnect()
        {
            chatClient.Disconnect();
        }

        private void ChangeConnect(bool isConnect)
        {
            isConnected = isConnect;

            mainWindow.ChangeConnectButton(isConnected);
            mainWindow.ChangeTextBoxAction(isConnected);
        }

        private void OnConnect()
        {
            isConnected = true;
            ChangeConnect(isConnected);
        }

        private void OnDisconnect()
        {
            isConnected = false;
            ChangeConnect(isConnected);
        }

        private void OnReceiveMessage(string message)
        {
            mainWindow.AddMassage(message);
        }
    }
}