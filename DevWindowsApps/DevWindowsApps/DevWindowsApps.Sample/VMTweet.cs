using System;
using AppStudio.DataProviders.Twitter;
using System.Windows.Input;

namespace DevWindowsApps.Sample
{
    public class VMTweet
    {
        public VMTweet(TwitterSchema tweet, ICommand userClickCommand, ICommand hashtagClickCommand)
        {
            this.CreationDateTime = tweet.CreationDateTime;
            this.Text = tweet.Text;
            this.Url = tweet.Url;
            this.UserId = tweet.UserId;
            this.UserName = tweet.UserName;
            this.UserProfileImageUrl = tweet.UserProfileImageUrl;
            this.UserScreenName = tweet.UserScreenName;            
            this.UserClickCommand = userClickCommand;
            this.HashtagClickCommand = hashtagClickCommand;
        }

        public DateTime CreationDateTime { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserProfileImageUrl { get; set; }
        public string UserScreenName { get; set; }
        public ICommand UserClickCommand { get; set; }
        public ICommand HashtagClickCommand { get; set; }
    }
}
