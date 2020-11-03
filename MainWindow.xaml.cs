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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Message messageWindow = new Message();
            messageWindow.ShowDialog();
            this.Close();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            File fileWindow = new File();
            fileWindow.ShowDialog();
            this.Close();
        }
    }
}
