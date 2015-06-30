using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class XboxMusicDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;

        public XboxMusicDetailPage()
        {
            this.ViewModel = new DetailViewModel<DynamicStorageDataConfig, XboxMusic1Schema>(new XboxMusicConfig());            
            this.InitializeComponent();
        }

        public DetailViewModel<DynamicStorageDataConfig, XboxMusic1Schema> ViewModel { get; set; }        

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
