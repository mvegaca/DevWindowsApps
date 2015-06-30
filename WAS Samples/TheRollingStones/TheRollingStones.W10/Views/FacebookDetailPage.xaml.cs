using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Facebook;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class FacebookDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;

        public FacebookDetailPage()
        {
            this.ViewModel = new DetailViewModel<FacebookDataConfig, FacebookSchema>(new FacebookConfig());            
            this.InitializeComponent();
        }

        public DetailViewModel<FacebookDataConfig, FacebookSchema> ViewModel { get; set; }        

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}
