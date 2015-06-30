using System;
using System.Windows.Input;
using AppStudio.Common;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using Windows.UI.Core;
using TheRollingStones.Navigation;

namespace TheRollingStones.ViewModels
{
    public class ShellViewModel : ObservableBase
    {
        private AppNavigation _navigation;
        private bool _navPanelOpened;
        private string _appTitle;

        public ShellViewModel()
        {
            Navigation = new AppNavigation();
            Navigation.LoadNavigation();

            NavigationService.NavigatedToPage += NavigationService_NavigatedToPage;
            SystemNavigationManager.GetForCurrentView().BackRequested += ((sender, e) =>
            {
                if (NavigationService.CanGoBack())
                {
                    e.Handled = true;
                    NavigationService.GoBack();
                }
            });
        }

        public AppNavigation Navigation
        {
            get { return _navigation; }
            set { SetProperty(ref _navigation, value); }
        }

        public bool NavPanelOpened
        {
            get { return _navPanelOpened; }
            set { SetProperty(ref _navPanelOpened, value); }
        }

        public string AppTitle
        {
            get { return _appTitle; }
            set { SetProperty(ref _appTitle, value); }
        }

        public ICommand ItemSelected
        {
            get
            {
                return new RelayCommand<NavigationNode>(n =>
                {
                    n.Selected();
                });
            }
        }

        public ICommand NavPanelClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    NavPanelOpened = !NavPanelOpened;
                });
            }
        }

        public ICommand GoBackCommand
        {
            get
            {
                return NavigationService.GoBackCommand;
            }
        }

        private void NavigationService_NavigatedToPage(object sender, NavigatedEventArgs e)
        {
            var navigatedNode = Navigation.FindPage(e.Page);
            if (navigatedNode != null)
            {
                if (!string.IsNullOrEmpty(navigatedNode.Title))
                {
                    AppTitle = navigatedNode.Title;
                }
                else
                {
                    AppTitle = navigatedNode.Label;
                }
                Navigation.Active = navigatedNode;
            }
            else
            {
                AppTitle = string.Empty;
                Navigation.Active = null;
            }

            if (NavPanelOpened)
            {
                NavPanelOpened = false;
            }
            if (NavigationService.CanGoBack())
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            OnPropertyChanged("GoBackCommand");
        }
    }
}
