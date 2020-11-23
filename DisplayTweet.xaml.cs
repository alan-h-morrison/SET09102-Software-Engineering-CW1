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
        private static ArrayList savedTweets;
        private int index;

        // Mentions list that stores all the instances a tweet mentions another user
        private static List<string> mentionList = new List<string>();

        // Hashtag dictionary, used to store the hashtags, count how many times they occur, used for a trending list
        private static Dictionary<string, int> hashtagList = new Dictionary<string, int>();

        // CONSTRUCTOR - Used to display window when navigating between display windows
        public DisplayTweet()
        {
            InitializeComponent();

            displayTrending();
            displayMentions();
        }

        // CONSTRUCTOR - Used to display tweet that has been created in the SubmitMessage window
        public DisplayTweet(Tweet newTweet)
        {
            InitializeComponent();

            // If the saved tweets list has not be intialised, intialise list
            if (savedTweets == null)
            {
                savedTweets = new ArrayList();
            }

            
            tweet = newTweet;

            // Add tweet to saved tweets list
            savedTweets.Add(tweet);
           
            // Add hashtags and counts the number of times a hashtag occurs to hashtag dictionary
            foreach (var hashtag in tweet.hashtagList)
            {
                if (hashtagList.ContainsKey(hashtag.ToString()))
                {
                    hashtagList[hashtag.ToString()]++;
                }
                else
                {
                    hashtagList[hashtag.ToString()] = 1;
                }
            }

            // Adds mentions to static mention list
            foreach(var mention in tweet.mentionList)
            {
                mentionList.Add(mention.ToString());
            }

            showTweet(tweet);
            displayTrending();
            displayMentions();
        }

        // METHOD - displays a tweet to screen
        private void showTweet(Tweet newTweet)
        {
            txtID.Text = tweet.tweetID;
            txtSender.Text = tweet.tweetSender;

            string str = String.Join(" ", tweet.tweetArray);
            txtContent.Text = str;
        }

        // METHOD - displays a trending list in decending order
        private void displayTrending()
        {
            // Use LINQ to sort trending list by decending no. of occurances
            var sortedHashtagList = from entry in hashtagList orderby entry.Value descending select entry;

            foreach (var item in sortedHashtagList)
            {
                lstTrending.Items.Add(item);
            }
        }

        // METHOD - displays the mentions list
        private void displayMentions()
        {
            // Retains the order of the values for future
            mentionList.Reverse();

            foreach (var item in mentionList)
            {
                lstMention.Items.Add(item);
            }
            mentionList.Reverse();
        }

        // BUTTON - return to main window
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        // BUTTON - displays the submit message window
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SubmitMessage submitMessage = new SubmitMessage();
            submitMessage.ShowDialog();
            this.Close();
        }

        // BUTTON - displays the sms window window
        private void btnSMS_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DisplaySMS displaySMS = new DisplaySMS();
            displaySMS.ShowDialog();
            this.Close();
        }

        // BUTTON - displays the email window window
        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            DisplayEmail displayEmail = new DisplayEmail();
            displayEmail.ShowDialog();
            this.Close();
        }

        // BUTTON - cycle through all of the saved tweets
        private void btnFoward_Click(object sender, RoutedEventArgs e)
        {
            if (index == savedTweets.Count)
            {
                index = 0;
            }

            tweet = (Tweet)savedTweets[index];

            showTweet(tweet);

            index++;
        }
    }
}
