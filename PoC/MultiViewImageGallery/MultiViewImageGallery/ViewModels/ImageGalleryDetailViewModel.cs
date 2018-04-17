using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MultiViewImageGallery.Helpers;
using MultiViewImageGallery.Models;
using MultiViewImageGallery.Services;
using MultiViewImageGallery.Views;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MultiViewImageGallery.ViewModels
{
    public class ImageGalleryDetailViewModel : Observable
    {
        private static UIElement _image;
        private object _selectedImage;
        private ObservableCollection<SampleImage> _source;
        private ICommand _openPhotoViewCommand;

        public ICommand OpenPhotoViewCommand => _openPhotoViewCommand ?? (_openPhotoViewCommand = new RelayCommand(OnOpenPhotoView));

        public object SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ApplicationData.Current.LocalSettings.SaveString(ImageGalleryViewModel.ImageGallerySelectedIdKey, ((SampleImage)SelectedImage).ID);
            }
        }

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ImageGalleryDetailViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData();
        }

        public void SetImage(UIElement image) => _image = image;

        public async Task InitializeAsync(SampleImage sampleImage, NavigationMode navigationMode)
        {
            if (sampleImage != null && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.FirstOrDefault(i => i.ID == sampleImage.ID);
            }
            else
            {
                var selectedImageId = await ApplicationData.Current.LocalSettings.ReadAsync<string>(ImageGalleryViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageId);
                }
            }

            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryViewModel.ImageGalleryAnimationOpen);
            animation?.TryStart(_image);
        }

        public void SetAnimation()
        {
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(ImageGalleryViewModel.ImageGalleryAnimationClose, _image);
        }

        private async void OnOpenPhotoView()
        {
            await WindowManagerService.Current.TryShowAsStandaloneAsync("PhotoDetail_Title.Text".GetLocalized(), typeof(ImageDetailPage));
        }
    }
}
