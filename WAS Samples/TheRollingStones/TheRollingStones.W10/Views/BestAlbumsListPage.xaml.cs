using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class BestAlbumsListPage : PageBase
    {
        public BestAlbumsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, BestAlbums1Schema>(new BestAlbumsConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, BestAlbums1Schema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
