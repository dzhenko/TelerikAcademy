using Chat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chat.Client.Wpf
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        private MongoData mongo;

        private DateTime lastUpdate;

        public MainWindow()
        {
            this.mongo = new MongoData(false);
            InitializeComponent();

            this.lastUpdate = new DateTime(2000, 1, 1);

            MessageSend.Visibility = System.Windows.Visibility.Hidden;
            MessagesList.Visibility = System.Windows.Visibility.Hidden;
            MessageText.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsernameClick.Visibility = System.Windows.Visibility.Hidden;
            Username.Visibility = System.Windows.Visibility.Hidden;

            MessageSend.Visibility = System.Windows.Visibility.Visible;
            MessagesList.Visibility = System.Windows.Visibility.Visible;
            MessageText.Visibility = System.Windows.Visibility.Visible;

            this.RefreshMessages();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.RefreshMessages();
        }

        private void MessageSend_Click(object sender, RoutedEventArgs e)
        {
            this.mongo.AddMessage(MessageText.Text, Username.Text == string.Empty ? "Guest" : Username.Text);

            this.MessageText.Text = string.Empty;

            this.RefreshMessages();
        }

        private void RefreshMessages()
        {
            var allMessages = this.mongo.GetMessagesSinceDate(this.lastUpdate);

            this.lastUpdate = DateTime.Now;

            foreach (var message in allMessages)
            {
                var content = string.Format("[{0}] [{1}] {2}", 
                    message.Date.ToString("hh-mm-ss"), message.User.Username, message.Text);

                ListBoxItem itm = new ListBoxItem();
                itm.Content = content;

                MessagesList.Items.Add(itm);
            }
        }
    }
}
