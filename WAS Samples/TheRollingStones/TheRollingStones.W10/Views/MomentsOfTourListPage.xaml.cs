using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TheRollingStones;
using TheRollingStones.Sections;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Views
{
    public sealed partial class MomentsOfTourListPage : PageBase
    {
        public MomentsOfTourListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, MomentsOfTour1Schema>(new MomentsOfTourConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, MomentsOfTour1Schema> ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
