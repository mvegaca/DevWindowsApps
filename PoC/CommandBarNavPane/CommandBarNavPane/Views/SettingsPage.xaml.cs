using System;
using System.Collections.Generic;
using CommandBarNavPane.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CommandBarNavPane.Views
{
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page, ICommandBarPage
    {
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();

        public IEnumerable<ICommandBarElement> PrimaryCommands
        {
            get
            {
                yield return new AppBarButton()
                {
                    Icon = new SymbolIcon(Symbol.Help),
                    Label = "Help",
                    Command = ViewModel.HelpCommand
                };
            }
        }

        public IEnumerable<ICommandBarElement> SecondaryCommands
        {
            get
            {
                yield break;
            }
        }

        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Initialize();
        }
    }
}
