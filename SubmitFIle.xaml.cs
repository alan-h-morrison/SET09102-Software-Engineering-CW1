using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using Microsoft.Win32;
using DataLayer;
using BusinessLayer;

namespace Bank
{
    /// <summary>
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : Window
    {
        string filePath = null;
        public File()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            Nullable<bool> path = openFileDialog.ShowDialog();

            if (path == true)
            {
                filePath = openFileDialog.FileName;
                txtPath.Text = filePath;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ReadFile file = new ReadFile(filePath);
            Message msg = new Message();

            try
            {
                if (file != null)
                {
                    msg.messageID = file.id.ToUpper();
                    msg.messageBody = file.body;

                    if (msg.messageID.StartsWith("S"))
                    {
                        SMS sms = msg.newSMS();

                        this.Hide();
                        DisplaySMS displayEmail = new DisplaySMS(sms);
                        displayEmail.ShowDialog();
                        this.Close();
                    }
                    else if (msg.messageID.StartsWith("E"))
                    {
                        Email email = msg.newEmail();

                        this.Hide();
                        DisplayEmail displayEmail = new DisplayEmail(email);
                        displayEmail.ShowDialog();
                        this.Close();
                    }
                    else if (msg.messageID.StartsWith("T"))
                    {
                        Tweet tweet = msg.newTweet();

                        this.Hide();
                        DisplayTweet displayTweet = new DisplayTweet(tweet);
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
