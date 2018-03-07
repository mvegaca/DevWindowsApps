using System;

using StaggeredPanel.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace StaggeredPanel.Views
{
    public sealed partial class MyPhotosPage : Page
    {
        public MyPhotosViewModel ViewModel { get; } = new MyPhotosViewModel();

        public MyPhotosPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize();
        }
    }
}
