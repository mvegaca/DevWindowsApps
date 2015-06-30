using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TheRollingStones.Layouts
{
    public sealed partial class PhotoDetailLayout : BaseDetailLayout
    {
        public static readonly DependencyProperty MaxWProperty =
            DependencyProperty.Register("MaxW", typeof(double), typeof(PhotoDetailLayout), new PropertyMetadata(0D));

        public static readonly DependencyProperty MaxHProperty =
            DependencyProperty.Register("MaxH", typeof(double), typeof(PhotoDetailLayout), new PropertyMetadata(0D));

        public PhotoDetailLayout()
        {
            InitializeComponent();
        }

        public double MaxW
        {
            get { return (double)GetValue(MaxWProperty); }
            set { SetValue(MaxWProperty, value); }
        }

        public double MaxH
        {
            get { return (double)GetValue(MaxHProperty); }
            set { SetValue(MaxHProperty, value); }
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaxH = e.NewSize.Height;
            MaxW = e.NewSize.Width;
        }

        private void ItemTapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                FlipView flip = sender as FlipView;
                bool currentValue = (bool)flip.Tag;
                flip.Tag = !currentValue;
            }
            catch (Exception)
            {
            }
        }
    }
}
