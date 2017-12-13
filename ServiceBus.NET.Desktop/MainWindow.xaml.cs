using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceBus.NET.Library;

namespace ServiceBus.NET.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ServiceBus.NET.Library.Messaging Messaging { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Messaging = new Messaging();

        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            //Send a message on the queue
            var message = MessageToSend.Text;
            var response = Messaging.SendMessage(message);
            MessagesReceived.Items.Add(response);
        }
    }
}
