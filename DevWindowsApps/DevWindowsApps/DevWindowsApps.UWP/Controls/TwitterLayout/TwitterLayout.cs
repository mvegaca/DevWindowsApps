using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace DevWindowsApps.UWP.Controls
{
    public sealed class TwitterLayout : Control
    {
        private static Color TwitterAccentColor = Color.FromArgb(255, 64, 153, 255);
        private static ICommand OpenUserInBrowser = new RelayCommand<string>(async (username)=>
        {
            var uri = new Uri(string.Format("http://www.twitter.com/{0}", username, UriKind.Absolute));
            await Launcher.LaunchUriAsync(uri);
        });
        private static ICommand OpenHashtagInBrowser = new RelayCommand<string>(async (hastag) =>
        {
            var uri = new Uri(string.Format("http://www.twitter.com/search?q={0}", hastag, UriKind.Absolute));
            await Launcher.LaunchUriAsync(uri);
        });

        public static readonly DependencyProperty AuthorProperty = DependencyProperty.Register("Author", typeof(string), typeof(TwitterLayout), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(TwitterLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty TweetProperty = DependencyProperty.Register("Tweet", typeof(string), typeof(TwitterLayout), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty CreationDateTimeProperty = DependencyProperty.Register("CreationDateTime", typeof(DateTime), typeof(TwitterLayout), new PropertyMetadata(DateTime.Now));
        public static readonly DependencyProperty LayoutAccentProperty = DependencyProperty.Register("LayoutAccent", typeof(Brush), typeof(TwitterLayout), new PropertyMetadata(new SolidColorBrush(TwitterAccentColor)));
        public static readonly DependencyProperty LayoutBackgroundProperty = DependencyProperty.Register("LayoutBackground", typeof(Brush), typeof(TwitterLayout), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        public static readonly DependencyProperty LayoutForegroundProperty = DependencyProperty.Register("LayoutForeground", typeof(Brush), typeof(TwitterLayout), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        public static readonly DependencyProperty LayoutPaddingProperty = DependencyProperty.Register("LayoutPadding", typeof(Thickness), typeof(TwitterLayout), new PropertyMetadata(new Thickness(12)));
        public static readonly DependencyProperty UserClickCommandProperty = DependencyProperty.Register("UserClickCommand", typeof(ICommand), typeof(TwitterLayout), new PropertyMetadata(OpenUserInBrowser));
        public static readonly DependencyProperty HashtagClickCommandProperty = DependencyProperty.Register("HashtagClickCommand", typeof(ICommand), typeof(TwitterLayout), new PropertyMetadata(OpenHashtagInBrowser));

        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public string Tweet
        {
            get { return (string)GetValue(TweetProperty); }
            set { SetValue(TweetProperty, value); }
        }

        public DateTime CreationDateTime
        {
            get { return (DateTime)GetValue(CreationDateTimeProperty); }
            set { SetValue(CreationDateTimeProperty, value); }
        }
        public Brush LayoutAccent
        {
            get { return (Brush)GetValue(LayoutAccentProperty); }
            set { SetValue(LayoutAccentProperty, value); }
        }
        public Brush LayoutBackground
        {
            get { return (Brush)GetValue(LayoutBackgroundProperty); }
            set { SetValue(LayoutBackgroundProperty, value); }
        }
        public Brush LayoutForeground
        {
            get { return (Brush)GetValue(LayoutForegroundProperty); }
            set { SetValue(LayoutForegroundProperty, value); }
        }
        public Thickness LayoutPadding
        {
            get { return (Thickness)GetValue(LayoutPaddingProperty); }
            set { SetValue(LayoutPaddingProperty, value); }
        }
        public ICommand UserClickCommand
        {
            get { return (ICommand)GetValue(UserClickCommandProperty); }
            set { SetValue(UserClickCommandProperty, value); }
        }
        public ICommand HashtagClickCommand
        {
            get { return (ICommand)GetValue(HashtagClickCommandProperty); }
            set { SetValue(HashtagClickCommandProperty, value); }
        }
        public TwitterLayout()
        {
            this.DefaultStyleKey = typeof(TwitterLayout);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var imageGrid = base.GetTemplateChild("imageGrid") as Grid;
            imageGrid.Background = new ImageBrush() { ImageSource = Image };
            var timeAgoTextBlock = base.GetTemplateChild("timeAgoTextBlock") as TextBlock;
            timeAgoTextBlock.Text = GetTimeAgoString(CreationDateTime);
            var authorName = base.GetTemplateChild("authorName") as TextBlock;
            authorName.Tapped += ((sender, args) =>
            {
                if (UserClickCommand != null && !string.IsNullOrEmpty(Author))
                {
                    if (UserClickCommand.CanExecute(Author))
                    {
                        UserClickCommand.Execute(Author);
                    }
                }
            });
            var words = Tweet.Split(' ');
            if (words != null && words.Count() > 0)
            {
                var tweetRichTextBlock = base.GetTemplateChild("tweetRichTextBlock") as RichTextBlock;
                tweetRichTextBlock.Blocks.Clear();
                Paragraph paragraph = new Paragraph();
                foreach (var word in words)
                {
                    if (word.StartsWith("#"))
                    {
                        Run run = new Run();
                        var hashtag = CleanUserOrHashtag(word);
                        run.Text = string.Format("#{0} ", hashtag);
                        Hyperlink link = new Hyperlink();
                        link.Inlines.Add(run);
                        link.Click += ((sender, args) =>
                        {
                            if (HashtagClickCommand != null)
                            {
                                if (HashtagClickCommand.CanExecute(hashtag))
                                {
                                    HashtagClickCommand.Execute(hashtag);
                                }
                            }
                        });
                        link.Foreground = LayoutAccent;
                        paragraph.Inlines.Add(link);
                    }
                    else if (word.StartsWith("@"))
                    {
                        Run run = new Run();
                        var user = CleanUserOrHashtag(word);
                        run.Text = string.Format("@{0} ", user);
                        Hyperlink link = new Hyperlink();
                        link.Inlines.Add(run);                        
                        link.Click += ((sender, args)=>
                        {
                            if (UserClickCommand != null)
                            {
                                if (UserClickCommand.CanExecute(user))
                                {
                                    UserClickCommand.Execute(user);
                                }
                            }
                        });
                        link.Foreground = LayoutAccent;                                                
                        paragraph.Inlines.Add(link);
                    }
                    else
                    {
                        Run run = new Run();
                        run.Text = string.Format("{0} ", word);                        
                        paragraph.Inlines.Add(run);                        
                    }
                }
                tweetRichTextBlock.Blocks.Add(paragraph);
            }
        }

        private string GetTimeAgoString(DateTime creationDateTime)
        {
            TimeSpan ts = DateTime.Now - creationDateTime;
            if (ts.TotalSeconds > 60)
            {
                if (ts.TotalMinutes > 60)
                {
                    if (ts.TotalHours > 24)
                    {
                        return string.Format("{0} days ago", Math.Truncate(ts.TotalDays));
                    }
                    else
                    {
                        return string.Format("{0} hours ago", Math.Truncate(ts.TotalHours));
                    }
                }
                else
                {
                    return string.Format("{0} minutes ago", Math.Truncate(ts.TotalMinutes));
                }
            }
            else
            {
                return string.Format("{0} seconds ago",Math.Truncate(ts.TotalSeconds));
            }
        }

        private string CleanUserOrHashtag(string user)
        {
            List<string> charsToRemove = new List<string>() { "#", "@", ":", ";", "." };
            string cleanedUser = user;
            foreach (string charToRemove in charsToRemove)
            {
                cleanedUser = cleanedUser.Replace(charToRemove, "");
            }
            return cleanedUser;
        }
    }
}