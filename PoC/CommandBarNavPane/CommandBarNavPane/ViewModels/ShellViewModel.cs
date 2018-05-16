using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using CommandBarNavPane.Helpers;
using CommandBarNavPane.Services;
using CommandBarNavPane.Views;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CommandBarNavPane.ViewModels
{
    public class ShellViewModel : Observable
    {
        private CommandBar _commandBar;
        private NavigationView _navigationView;
        private NavigationViewItem _selected;
        private ICommand _itemInvokedCommand;
        private Page _currentPage;

        public NavigationViewItem Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ICommand ItemInvokedCommand => _itemInvokedCommand ?? (_itemInvokedCommand = new RelayCommand<NavigationViewItemInvokedEventArgs>(OnItemInvoked));

        //public readonly ObservableCollection<ICommandBarElement> PrimaryCommands = new ObservableCollection<ICommandBarElement>();

        internal void SetCommandBar(CommandBar commandBar)
        {
            _commandBar = commandBar;
            UpdateCommands();
        }

        public ShellViewModel()
        {
        }

        public void Initialize(Frame frame, NavigationView navigationView)
        {
            _navigationView = navigationView;
            NavigationService.Frame = frame;
            NavigationService.Navigated += Frame_Navigated;
        }

        private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                NavigationService.Navigate(typeof(SettingsPage));
                return;
            }

            var item = _navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);
            var pageType = item.GetValue(NavHelper.NavigateToProperty) as Type;
            NavigationService.Navigate(pageType);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.SourcePageType == typeof(SettingsPage))
            {
                Selected = _navigationView.SettingsItem as NavigationViewItem;                
            }
            else
            {
                Selected = _navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, e.SourcePageType));
            }
            _currentPage = e.Content as Page;
            UpdateCommands();
        }

        private void UpdateCommands()
        {
            if (_commandBar != null && _currentPage != null)
            {
                _commandBar.PrimaryCommands.Clear();
                _commandBar.SecondaryCommands.Clear();
                if (_currentPage is ICommandBarPage commandBarPage)
                {
                    foreach (var command in commandBarPage.PrimaryCommands)
                    {
                        _commandBar.PrimaryCommands.Add(command);
                    }
                    foreach (var command in commandBarPage.SecondaryCommands)
                    {
                        _commandBar.SecondaryCommands.Add(command);
                    }
                }
            }
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var pageType = menuItem.GetValue(NavHelper.NavigateToProperty) as Type;
            return pageType == sourcePageType;
        }
    }
}
