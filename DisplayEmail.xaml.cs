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
    /// <summary>
    /// Interaction logic for DisplayEmail.xaml
    /// </summary>
    public partial class DisplayEmail : Window
    {
        private Email email;
        public DisplayEmail(Email newEmail)
        {
            InitializeComponent();

            email = newEmail;

            txtID.Text = email.emailID;
            txtSender.Text = email.emailSender.ToString();
            txtSubject.Text = email.emailSubject;

            string str = String.Join("\n", email.emailBody);
            txtBody.Text = str;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
