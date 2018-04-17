using System;
using System.Linq;
using System.Threading.Tasks;
using MultiViewImageGallery.Helpers;
using MultiViewImageGallery.Services;
using Windows.Storage;
using Windows.UI.Core;

namespace MultiViewImageGallery.ViewModels
{
    public class ImageDetailViewModel : Observable
    {
        private object _selectedImage;
        private ViewLifetimeControl _viewLifetimeControl;

        public object SelectedImage
        {
            get => _selectedImage;
            set => Set(ref _selectedImage, value);
        }

        public ImageDetailViewModel()
        {
        }

        public async Task InitializeAsync(ViewLifetimeControl viewLifetimeControl)
        {
            _viewLifetimeControl = viewLifetimeControl;
            _viewLifetimeControl.Released += OnViewLifetimeControlReleased;

            var imageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGalleryViewModel.ImageGallerySelectedIdKey);

            SelectedImage = SampleDataService.GetGallerySampleData().FirstOrDefault(i => i.ID == imageId);
        }

        private async void OnViewLifetimeControlReleased(object sender, EventArgs e)
        {
            _viewLifetimeControl.Released -= OnViewLifetimeControlReleased;
            await WindowManagerService.Current.MainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                WindowManagerService.Current.SecondaryViews.Remove(_viewLifetimeControl);
            });
        }
    }
}
