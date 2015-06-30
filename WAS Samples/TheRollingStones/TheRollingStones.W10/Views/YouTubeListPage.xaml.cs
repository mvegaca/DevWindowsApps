using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class YouTubeListPage : PageBase
    {
        public YouTubeListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new YouTubeConfig());
            this.InitializeComponent();
        }

        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
