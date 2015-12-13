using AppStudio.DataProviders.Twitter;
using DevWindowsApps.UWP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevWindowsApps.Sample
{
    public class VMTwitter : Observable
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { SetProperty(ref _searchTerm, value); }
        }
        private ObservableCollection<TwitterSchema> _items;
        public ObservableCollection<TwitterSchema> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);                
            }
        }

        private TwitterDataProvider _dataProvider;
        private TwitterOAuthTokens _tokens;
        private TwitterDataConfig _config;
        public VMTwitter()
        {
            Items = new ObservableCollection<TwitterSchema>();
            _tokens = new TwitterOAuthTokens()
            {
                ConsumerKey = "29TPMHBW0QcFIWvNrfWxUGmlV",
                ConsumerSecret = "7cp8HDzES42iAFGgE5yxJ3wAxsrDdu5uEHwhoOKPlN6Q2P8k6s",
                AccessToken = "275442106-OdbhPuGr8biRdQsHbtzNSMVvHRrX9acsLbiyYgCF",
                AccessTokenSecret = "GA4Uw2sMgvSayjWTw9qdejB8LzNfNS2cAaQPimVDVhdIP"
            };
            SearchTerm = "UWP";
            _config = new TwitterDataConfig() { QueryType = TwitterQueryType.Search, Query = SearchTerm };
            _dataProvider = new TwitterDataProvider(_tokens);
        }
        public async Task LoadData()
        {
            if (Items.Count == 0)
            {
                _config.Query = SearchTerm;
                var tweets = await _dataProvider.LoadDataAsync(_config);
                foreach (var tweet in tweets)
                {
                    Items.Add(tweet);
                }
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Items.Clear();
                    await LoadData();
                });
            }
        }        
    }
}
