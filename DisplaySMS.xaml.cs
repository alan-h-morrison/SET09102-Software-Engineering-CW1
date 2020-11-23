using BusinessLayer;
using System;
using System.Collections;
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

namespace Bank
{
    public partial class DisplaySMS : Window
    {
        private SMS sms;
        private static ArrayList savedSMS; // static arraylist to keep track of every sms passed through the program
        int index = 0;

        // CONSTRUCTOR - Used when navigating between different display windows
        public DisplaySMS()
        {
            InitializeComponent();
        }

        // CONSTRUCTOR - Used when a new sms has been submitted
        public DisplaySMS(SMS newSMS)
        {
            InitializeComponent();

            // if a list hasnt been created yet, create the list
            if(savedSMS == null)
            {
                savedSMS = new ArrayList();
            }

            sms = newSMS;

            // Add the new sms to the saved list
            savedSMS.Add(sms);

            showSMS(sms);
        }

        // METHOD - prints sms to screen
        private void showSMS(SMS newSMS)
        {
            txtID.Text = sms.smsID;
            txtSender.Text = sms.smsSender;

            string str = String.Join(" ", sms.smsArray);
            txtContent.Text = str;
        }

        // BUTTON - opens main window
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        // BUTTON - opens submit message window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SubmitMessage submitMessage = new SubmitMessage();
            submitMessage.ShowDialog();
            this.Close();
        }

        // BUTTON - opens display tweet window
        private void btnTweet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DisplayTweet displayTweet = new DisplayTweet();
            displayTweet.ShowDialog();
            this.Close();
        }

        // BUTTON - opens display email window
        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DisplayEmail displayEmail = new DisplayEmail();
            displayEmail.ShowDialog();
            this.Close();
        }

        // BUTTON - used to cycle through all the saved sms'
        private void btnFoward_Click(object sender, RoutedEventArgs e)
        {
            // If index exceeds the size of the array list, set the index back to 0
            if (index == savedSMS.Count)
            {
                index = 0;
            }

            sms = (SMS)savedSMS[index];

            showSMS(sms);

            index++;
        }
    }
}
