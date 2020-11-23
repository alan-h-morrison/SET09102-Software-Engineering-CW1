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
using BusinessLayer;

namespace Bank
{
    public partial class DisplayEmail : Window
    {
        private Email email;
        private static ArrayList savedEmail;
        private static ArrayList sirList;
        int index;

        // CONTRUCTOR - Used when navigating from different display windows
        public DisplayEmail()
        {
            InitializeComponent();

            // Initialise SIR list and saved emails list if they are not null
            if (sirList == null)
            {
                sirList = new ArrayList();
            }

            if (savedEmail == null)
            {
                savedEmail = new ArrayList();
            }

            displaySIR();
        }

        // CONTRUCTOR - Used when a new tweet has been submitted
        public DisplayEmail(Email newEmail)
        {
            InitializeComponent();

            // Initialise SIR list and saved emails list if they are not null
            if (sirList == null)
            {
                sirList = new ArrayList();
            }

            if (savedEmail == null)
            {
                savedEmail = new ArrayList();
            }

            // Checks if an email is a SIR and adds it to SIR list
            if (newEmail.isSIR)
            {
                sirList.Add(newEmail);
            }

            email = newEmail;

            showEmail(email);
            displaySIR();
            displayURL();
        }

        // METHOD - Prints email to screen
        private void showEmail(Email newEmail)
        {
            // Adds every email to a saved email list
            savedEmail.Add(newEmail);

            txtID.Text = newEmail.emailID;
            txtSender.Text = newEmail.emailSender.ToString();
            txtSubject.Text = newEmail.emailSubject;

            string str = String.Join("\n", newEmail.emailBody);
            txtBody.Text = str;
        }

        //  Displays all the SIRs saved in SIR list
        private void displaySIR()
        {
            foreach (Email item in sirList)
            {
                lstSIR.Items.Add("Sort Code: " + item.sortCode + " Report: " + item.sirIncident);
            }
        }

        // METHOD - Displays all the qurantined urls
        private void displayURL()
        {
            // Clears any urls from previous email
            lstURL.Items.Clear();

            foreach (string url in email.urlList)
            {
                lstURL.Items.Add(url);
            }
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

        // BUTTON - opens display window window
        private void btnSMS_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DisplaySMS displaySMS = new DisplaySMS();
            displaySMS.ShowDialog();
            this.Close();
        }

        // BUTTON - used to cycle through all teh saved emails
        private void btnFoward_Click(object sender, RoutedEventArgs e)
        {
            if (index == savedEmail.Count - 1)
            {
                index = 0;
            }

            email = (Email)savedEmail[index];

            showEmail(email);
            displayURL();

            index++;
        }
    }
}
