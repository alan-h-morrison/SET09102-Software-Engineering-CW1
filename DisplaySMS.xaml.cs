using BusinessLayer;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for DisplaySMS.xaml
    /// </summary>
    public partial class DisplaySMS : Window
    {
        private SMS sms;
        public DisplaySMS(SMS newSMS)
        {
            InitializeComponent();

            sms = newSMS;

            txtID.Text = sms.smsID;
            txtSender.Text = sms.smsSender;

            string str = String.Join(" ", sms.smsArray);
            txtContent.Text = str;
        }
    }
}
