using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.DynamicStorage;
using TheRollingStones.Sections;


namespace TheRollingStones.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            BestAlbums = new ListViewModel<DynamicStorageDataConfig, BestAlbums1Schema>(new BestAlbumsConfig(), visibleItems);
            News = new ListViewModel<RssDataConfig, RssSchema>(new NewsConfig(), visibleItems);
            MomentsOfTour = new ListViewModel<DynamicStorageDataConfig, MomentsOfTour1Schema>(new MomentsOfTourConfig(), visibleItems);
            RollingConected = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new RollingConectedConfig());
            XboxMusic = new ListViewModel<DynamicStorageDataConfig, XboxMusic1Schema>(new XboxMusicConfig(), visibleItems);
            TourPlan = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new TourPlanConfig());
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public ListViewModel<DynamicStorageDataConfig, BestAlbums1Schema> BestAlbums { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> News { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, MomentsOfTour1Schema> MomentsOfTour { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> RollingConected { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, XboxMusic1Schema> XboxMusic { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> TourPlan { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return BestAlbums;
            yield return News;
            yield return MomentsOfTour;
            yield return RollingConected;
            yield return XboxMusic;
            yield return TourPlan;
        }
    }
}
