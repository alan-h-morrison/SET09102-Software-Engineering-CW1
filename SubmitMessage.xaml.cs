using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;

namespace Bank
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class SubmitMessage : Window
    {
        private MainWindow mainWindow;
        private DisplayEmail displayEmail;
        private DisplaySMS displaySMS;
        private DisplayTweet displayTweet;

        public SubmitMessage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtID.Clear();
            txtBody.Clear();
        }

        private void btnClearID_Click(object sender, RoutedEventArgs e)
        {
            txtID.Clear();
        }

        private void btnClearMessage_Click(object sender, RoutedEventArgs e)
        {
            txtBody.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Message msg = new Message();

            try
            {
                if (txtID.Text != "" || txtBody.Text != "")
                {
                    msg.messageID = txtID.Text;
                    msg.messageBody = txtBody.Text;

                    if (msg.messageID.StartsWith("S"))
                    {
                        SMS sms = msg.newSMS();

                        this.Hide();
                        displaySMS = new DisplaySMS(sms);
                        displaySMS.ShowDialog();
                        this.Close();
                    }
                    else if (msg.messageID.StartsWith("E"))
                    {
                        Email email = msg.newEmail();

                        this.Hide();
                        displayEmail = new DisplayEmail(email);
                        displayEmail.ShowDialog();
                        this.Close();
                    }
                    else if (msg.messageID.StartsWith("T"))
                    {
                        Tweet tweet = msg.newTweet();

                        this.Hide();
                        displayTweet = new DisplayTweet(tweet);
                        displayTweet.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
