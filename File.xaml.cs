using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using Microsoft.Win32;

namespace Bank
{
    /// <summary>
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : Window
    {
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
                string filename = openFileDialog.FileName;
                txtPath.Text = filename;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

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
