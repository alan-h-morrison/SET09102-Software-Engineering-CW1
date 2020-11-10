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
        public SubmitMessage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
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
            string test = null;

            try
            {
                if (txtID.Text != "" || txtBody.Text != "")
                {
                    msg.messageID = txtID.Text.ToUpper();
                    msg.messageBody = txtBody.Text;

                    if (msg.messageID.StartsWith("S"))
                    {
                        msg.newSMS();
                    }
                    else if (msg.messageID.StartsWith("E"))
                    {
                        msg.newEmail();
                    }
                    else if (msg.messageID.StartsWith("T"))
                    {
                        msg.newTweet();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

           

            MessageBox.Show("id: " + msg.messageID + "\nbody: " + msg.messageBody + "\nmessage type: " + test);
        }
    }
}
