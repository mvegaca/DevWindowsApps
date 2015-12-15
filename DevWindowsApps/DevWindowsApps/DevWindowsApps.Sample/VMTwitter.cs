using AppStudio.DataProviders.Exceptions;
using AppStudio.DataProviders.Twitter;
using AppStudio.Uwp.Navigation;
using DevWindowsApps.UWP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;

namespace DevWindowsApps.Sample
{
    public class VMTwitter : Observable
    {
        private const string TitleSymbolUser = "@";
        private const string TitleSymbolHastag = "#";
        private string _query;
        private TwitterQueryType _queryType;
        private ObservableCollection<VMTweet> _items;
        private string _titleSymbol;        
        public string Query
        {
            get { return _query; }
            set { SetProperty(ref _query, value); }
        }
        public TwitterQueryType QueryType
        {
            get { return _queryType; }
            set
            {
                SetProperty(ref _queryType, value);
                TitleSymbol = (value == TwitterQueryType.User) ? TitleSymbolUser : TitleSymbolHastag;
            }
        }
        public string TitleSymbol
        {
            get { return _titleSymbol; }
            set { SetProperty(ref _titleSymbol, value); }
        }
        public ObservableCollection<VMTweet> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private TwitterDataProvider _dataProvider;
        private TwitterOAuthTokens _tokens;
        private TwitterDataConfig _config;
        public VMTwitter()
        {
            Items = new ObservableCollection<VMTweet>();
            _tokens = new TwitterOAuthTokens()
            {
                ConsumerKey = "29TPMHBW0QcFIWvNrfWxUGmlV",
                ConsumerSecret = "7cp8HDzES42iAFGgE5yxJ3wAxsrDdu5uEHwhoOKPlN6Q2P8k6s",
                AccessToken = "275442106-OdbhPuGr8biRdQsHbtzNSMVvHRrX9acsLbiyYgCF",
                AccessTokenSecret = "GA4Uw2sMgvSayjWTw9qdejB8LzNfNS2cAaQPimVDVhdIP"
            };
            Query = "mvegaca";
            QueryType = TwitterQueryType.User;
            _config = new TwitterDataConfig();
            _dataProvider = new TwitterDataProvider(_tokens);
        }
        public async Task LoadData()
        {
            _config.QueryType = QueryType;
            _config.Query = Query;
            IEnumerable<TwitterSchema> tweets;
            try
            {
                tweets = await _dataProvider.LoadDataAsync(_config);
            }
            catch (UserNotFoundException)
            {
                tweets = null;
            }
            catch (TooManyRequestsException)
            {
                tweets = null;
            }
            catch (Exception)
            {
                tweets = null;
            }
            if (tweets != null)
            {
                Items.Clear();
                foreach (var tweet in tweets)
                {
                    Items.Add(new VMTweet(tweet, UserClickCommand, HashtagClickCommand));
                }
            }            
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {                    
                    await LoadData();
                });
            }
        }
        public ICommand UserClickCommand
        {
            get
            {
                return new RelayCommand<string>(async (user) =>
                {
                    QueryType = TwitterQueryType.User;
                    Query = user;
                    await LoadData();
                });
            }
        }
        public ICommand HashtagClickCommand
        {
            get
            {
                return new RelayCommand<string>(async (hashtag) =>
                {
                    QueryType = TwitterQueryType.Search;
                    Query = hashtag;
                    await LoadData();
                });
            }
        }
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand<string>((pageName) =>
                {
                    NavigationService.NavigateToPage(pageName);
                });
            }
        }        
    }
}
