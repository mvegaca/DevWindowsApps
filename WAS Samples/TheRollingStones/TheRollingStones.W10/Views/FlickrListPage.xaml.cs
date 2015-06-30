using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Flickr;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class FlickrListPage : PageBase
    {
        public FlickrListPage()
        {
            this.ViewModel = new ListViewModel<FlickrDataConfig, FlickrSchema>(new FlickrConfig());
            this.InitializeComponent();
        }

        public ListViewModel<FlickrDataConfig, FlickrSchema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
