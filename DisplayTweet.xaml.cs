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
    /// <summary>
    /// Interaction logic for DisplayTweet.xaml
    /// </summary>
    public partial class DisplayTweet : Window
    {
        private Tweet tweet;
        private ArrayList sirList;
        public DisplayTweet(Tweet newTweet)
        {
            InitializeComponent();

            tweet = newTweet;

            txtID.Text = tweet.tweetID;
            txtSender.Text = tweet.tweetSender;

            string str = String.Join(" ", tweet.tweetArray);
            txtContent.Text = str;

        }
    }
}
