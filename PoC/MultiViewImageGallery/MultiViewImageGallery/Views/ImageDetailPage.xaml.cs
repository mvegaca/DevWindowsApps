using System;
using MultiViewImageGallery.Services;
using MultiViewImageGallery.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MultiViewImageGallery.Views
{
    public sealed partial class ImageDetailPage : Page
    {
        public ImageDetailViewModel ViewModel { get; } = new ImageDetailViewModel();

        public ImageDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.InitializeAsync(e.Parameter as ViewLifetimeControl);
        }
    }
}
