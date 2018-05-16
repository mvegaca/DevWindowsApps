using System;
using System.Collections.Generic;
using CommandBarNavPane.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CommandBarNavPane.Views
{
    public sealed partial class MainPage : Page, ICommandBarPage
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public IEnumerable<ICommandBarElement> PrimaryCommands
        {
            get
            {
                yield return new AppBarButton()
                {
                    Icon = new SymbolIcon(Symbol.Like),
                    Label = "Like",
                    Command = ViewModel.LikeCommand
                };
            }
        }

        public IEnumerable<ICommandBarElement> SecondaryCommands
        {
            get
            {
                yield return new AppBarButton()
                {
                    Icon = new SymbolIcon(Symbol.Message),
                    Label = "Comments",
                    Command = ViewModel.CommentsCommand
                };
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
