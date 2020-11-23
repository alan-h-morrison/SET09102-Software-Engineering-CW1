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

        //BACK BUTTON - returns to main window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        // CLEAR ALL BUTTON - clear text from id and message field
        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtID.Clear();
            txtBody.Clear();
        }

        // CLEAR ID BUTTON - clear text from id field
        private void btnClearID_Click(object sender, RoutedEventArgs e)
        {
            txtID.Clear();
        }

        // CLEAR MESSAGE BUTTON - clear text from message field
        private void btnClearMessage_Click(object sender, RoutedEventArgs e)
        {
            txtBody.Clear();
        }

        // SUBMIT BUTTON - process message entered in fields and display it to the screen
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Message msg = new Message();

            // Try-Catch loop that detects argument exception
            try
            {
                // checks if the header and body are not empty
                if (txtID.Text != "" || txtBody.Text != "")
                {
                    msg.messageID = txtID.Text;
                    msg.messageBody = txtBody.Text;

                    // Checks the id to identify the type of message that is generated
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
