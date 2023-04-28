using ChatClient.Model;
using System;
using System.Windows;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string CONNECT = "Connect";
        private const string DISCONNECT = "Disconnect";

        public delegate void UpdateTextCallback(string message);

        private Presenter presenter;

        public string UserName => tb_user_name.Text;

        public MainWindow()
        {
            InitializeComponent();

            tb_ip_address.Text = "192.168.1.106";
            tb_port.Text = "8888";
            presenter = new Presenter(this, new TcpChatClientModel());
        }

        #region "UpdateUI"
        public void AddMassage(string message)
        {
            lb_chat.Dispatcher.Invoke(
                new UpdateTextCallback(this.UpdateText),
                message
            );
        }

        public void ChangeConnectButton(bool isConnected)
        {
            bt_connect.Content = isConnected ? DISCONNECT : CONNECT;
        }

        public void ChangeTextBoxAction(bool isConnected)
        {
            tb_ip_address.IsEnabled = !isConnected;
            tb_port.IsEnabled = !isConnected;
            tb_user_name.IsEnabled = !isConnected;
        }

        public void CleanSendMessage() =>
            tb_message.Text = "";

        private void UpdateText(string message)
        {
            lb_chat.Items.Add(message);
        }
        #endregion "UpdateUI"

        #region "UserAction"
        private void Connect()
        {
            presenter.Connect(tb_ip_address.Text, Int32.Parse(tb_port.Text), tb_user_name.Text);
        }

        private void SendMessage()
        {
            presenter.SendMessage(tb_message.Text);
        }
        #endregion "UserAction"

        #region "FormsActions"
        private void bt_send_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void bt_connect_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }
        #endregion "FormsActions"
    }
}
