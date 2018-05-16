using CommandBarNavPane.ViewModels;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CommandBarNavPane.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            HideNavViewBackButton();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView);
        }

        private void HideNavViewBackButton()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 6))
            {
                navigationView.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
            }
        }

        private void CommandBar_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SetCommandBar(sender as CommandBar);
        }
    }
}
