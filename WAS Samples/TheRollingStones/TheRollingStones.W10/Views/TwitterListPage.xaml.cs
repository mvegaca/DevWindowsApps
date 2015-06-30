using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class TwitterListPage : PageBase
    {
        public TwitterListPage()
        {
            this.ViewModel = new ListViewModel<TwitterDataConfig, TwitterSchema>(new TwitterConfig());
            this.InitializeComponent();
        }

        public ListViewModel<TwitterDataConfig, TwitterSchema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
