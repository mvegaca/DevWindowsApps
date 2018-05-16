using System;
using System.Windows.Input;
using CommandBarNavPane.Helpers;
using CommandBarNavPane.Views;
using Windows.UI.Popups;

namespace CommandBarNavPane.ViewModels
{
    public class MainViewModel : Observable
    {
        private ICommand _likeCommand;
        private ICommand _commentsCommand;

        public ICommand LikeCommand => _likeCommand ?? (_likeCommand = new RelayCommand(OnLike));

        public ICommand CommentsCommand => _commentsCommand ?? (_commentsCommand = new RelayCommand(OnComments));

        public MainViewModel()
        {
        }

        private static async void OnLike()
        {
            await new MessageDialog("Like command invoked!", "Message from command in MainViewModel").ShowAsync();
        }

        private async void OnComments()
        {
            await new MessageDialog("Comments command invoked!", "Message from command in MainViewModel").ShowAsync();
        }
    }
}
