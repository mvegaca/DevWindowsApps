using System.ComponentModel;
using System.Windows.Input;
using AppStudio.Common.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheRollingStones.Layouts
{
    public abstract class BaseListLayout : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(BaseListLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty ItemClickCommandProperty =
            DependencyProperty.Register("ItemClickCommand", typeof(ICommand), typeof(BaseListLayout), new PropertyMetadata(null));
        public static readonly DependencyProperty OneRowModeEnabledProperty =
            DependencyProperty.Register("OneRowModeEnabled", typeof(bool), typeof(BaseListLayout), new PropertyMetadata(false));

        public event PropertyChangedEventHandler PropertyChanged;

        private double _imageHeight;
        private double _imageWidth;
        private double _itemHeight;
        private int _titleMaxLines;
        private double _titleFontSize;
        private double _subTitleFontSize;
        private Thickness _leftMarginTitle;
        private Thickness _leftMarginSubTitle;
        private Thickness _boxLeftMarginTitle;
        private Thickness _boxLeftMarginSubTitle;
        private Thickness _menuMargin;
        private Thickness _itemMargin;

        public BaseListLayout()
        {
            Loaded += UCLoaded;
            SizeChanged += UCSizeChanged;
        }

        //--------------------------------------------------        
        protected abstract double VBPDesiredWidth0 { get; }
        protected abstract double VBPImageHeight0 { get; }
        protected abstract double VBPImageWidth0 { get; }
        protected abstract double VBPItemHeight0 { get; }
        protected abstract int VBPTitleMaxLines0 { get; }
        protected abstract double VBPTitleFontSize0 { get; }
        protected abstract double VBPSubTitleFontSize0 { get; }
        protected abstract double VBPMarginUnit0 { get; }
        protected abstract double VBPItemMargin0 { get; }
        //--------------------------------------------------        
        protected abstract double VisualBreakPointWidth0 { get; }
        //--------------------------------------------------        
        protected abstract double VBPDesiredWidth1 { get; }
        protected abstract double VBPImageHeight1 { get; }
        protected abstract double VBPImageWidth1 { get; }
        protected abstract double VBPItemHeight1 { get; }
        protected abstract int VBPTitleMaxLines1 { get; }
        protected abstract double VBPTitleFontSize1 { get; }
        protected abstract double VBPSubTitleFontSize1 { get; }
        protected abstract double VBPMarginUnit1 { get; }
        protected abstract double VBPItemMargin1 { get; }
        //--------------------------------------------------
        protected abstract double VisualBreakPointWidth1 { get; }
        //protected double VisualBreakPointWidth1 = 500;
        //--------------------------------------------------
        protected abstract double VBPDesiredWidth2 { get; }
        protected abstract double VBPImageHeight2 { get; }
        protected abstract double VBPImageWidth2 { get; }
        protected abstract double VBPItemHeight2 { get; }
        protected abstract int VBPTitleMaxLines2 { get; }
        protected abstract double VBPTitleFontSize2 { get; }
        protected abstract double VBPSubTitleFontSize2 { get; }
        protected abstract double VBPMarginUnit2 { get; }
        protected abstract double VBPItemMargin2 { get; }
        //--------------------------------------------------
        protected abstract double VisualBreakPointWidth2 { get; }
        //protected double VisualBreakPointWidth2 = 900;        
        //--------------------------------------------------
        protected abstract double VBPDesiredWidth3 { get; }
        protected abstract double VBPImageHeight3 { get; }
        protected abstract double VBPImageWidth3 { get; }
        protected abstract double VBPItemHeight3 { get; }
        protected abstract int VBPTitleMaxLines3 { get; }
        protected abstract double VBPTitleFontSize3 { get; }
        protected abstract double VBPSubTitleFontSize3 { get; }
        protected abstract double VBPMarginUnit3 { get; }
        protected abstract double VBPItemMargin3 { get; }
        //--------------------------------------------------
        protected abstract double VisualBreakPointWidth3 { get; }
        //protected double VisualBreakPointWidth3 = 1140;
        //--------------------------------------------------
        protected abstract double VBPDesiredWidth4 { get; }
        protected abstract double VBPImageHeight4 { get; }
        protected abstract double VBPImageWidth4 { get; }
        protected abstract double VBPItemHeight4 { get; }
        protected abstract int VBPTitleMaxLines4 { get; }
        protected abstract double VBPTitleFontSize4 { get; }
        protected abstract double VBPSubTitleFontSize4 { get; }
        protected abstract double VBPMarginUnit4 { get; }
        protected abstract double VBPItemMargin4 { get; }
        //--------------------------------------------------
        protected abstract double VisualBreakPointWidth4 { get; }
        //protected double VisualBreakPointWidth4 = 1820;
        //--------------------------------------------------        
        protected abstract double VBPDesiredWidth5 { get; }
        protected abstract double VBPImageHeight5 { get; }
        protected abstract double VBPImageWidth5 { get; }
        protected abstract double VBPItemHeight5 { get; }
        protected abstract int VBPTitleMaxLines5 { get; }
        protected abstract double VBPTitleFontSize5 { get; }
        protected abstract double VBPSubTitleFontSize5 { get; }
        protected abstract double VBPMarginUnit5 { get; }
        protected abstract double VBPItemMargin5 { get; }
        //--------------------------------------------------

        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public ICommand ItemClickCommand
        {
            get { return (ICommand)GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }
        public bool OneRowModeEnabled
        {
            get { return (bool)GetValue(OneRowModeEnabledProperty); }
            set { SetValue(OneRowModeEnabledProperty, value); }
        }

        public double ImageHeight
        {
            get { return _imageHeight; }
            set { this._imageHeight = value; OnPropertyChanged("ImageHeight"); }
        }
        public double ImageWidth
        {
            get { return _imageWidth; }
            set { this._imageWidth = value; OnPropertyChanged("ImageWidth"); }
        }
        public double ItemHeight
        {
            get { return _itemHeight; }
            set { this._itemHeight = value; OnPropertyChanged("ItemHeight"); }
        }
        public int TitleMaxLines
        {
            get { return _titleMaxLines; }
            set { this._titleMaxLines = value; OnPropertyChanged("TitleMaxLines"); }
        }
        public double TitleFontSize
        {
            get { return _titleFontSize; }
            set { this._titleFontSize = value; OnPropertyChanged("TitleFontSize"); }
        }
        public double SubTitleFontSize
        {
            get { return _subTitleFontSize; }
            set { this._subTitleFontSize = value; OnPropertyChanged("SubTitleFontSize"); }
        }
        public Thickness LeftMarginTitle
        {
            get { return _leftMarginTitle; }
            set { this._leftMarginTitle = value; OnPropertyChanged("LeftMarginTitle"); }
        }
        public Thickness LeftMarginSubTitle
        {
            get { return _leftMarginSubTitle; }
            set { this._leftMarginSubTitle = value; OnPropertyChanged("LeftMarginSubTitle"); }
        }
        public Thickness BoxLeftMarginTitle
        {
            get { return _boxLeftMarginTitle; }
            set { this._boxLeftMarginTitle = value; OnPropertyChanged("BoxLeftMarginTitle"); }
        }
        public Thickness BoxLeftMarginSubTitle
        {
            get { return _boxLeftMarginSubTitle; }
            set { this._boxLeftMarginSubTitle = value; OnPropertyChanged("BoxLeftMarginSubTitle"); }
        }
        public Thickness MenuMargin
        {
            get { return _menuMargin; }
            set { this._menuMargin = value; OnPropertyChanged("MenuMargin"); }
        }
        public Thickness ItemMargin
        {
            get { return _itemMargin; }
            set { this._itemMargin = value; OnPropertyChanged("ItemMargin"); }
        }

        public void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected abstract ResponsiveGridView GridView();

        private void RefreshLayout()
        {
            var w = Window.Current.Bounds.Width;
            if (w < VisualBreakPointWidth0)
            {
                GridView().RefreshLayout(VBPDesiredWidth0);
                ImageHeight = VBPImageHeight0;
                ImageWidth = VBPImageWidth0;
                ItemHeight = VBPItemHeight0;
                TitleMaxLines = VBPTitleMaxLines0;
                TitleFontSize = VBPTitleFontSize0;
                SubTitleFontSize = VBPSubTitleFontSize0;
                LeftMarginTitle = new Thickness(VBPMarginUnit0, 0, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit0, VBPMarginUnit0, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit0, VBPMarginUnit0, VBPMarginUnit0, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit0, VBPMarginUnit0, VBPMarginUnit0, VBPMarginUnit0);
                MenuMargin = new Thickness(0, VBPMarginUnit0, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin0);
            }
            else if (w < VisualBreakPointWidth1)
            {
                GridView().RefreshLayout(VBPDesiredWidth1);
                ImageHeight = VBPImageHeight1;
                ImageWidth = VBPImageWidth1;
                ItemHeight = VBPItemHeight1;
                TitleMaxLines = VBPTitleMaxLines1;
                TitleFontSize = VBPTitleFontSize1;
                SubTitleFontSize = VBPSubTitleFontSize1;
                LeftMarginTitle = new Thickness(VBPMarginUnit1, -6, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit1, VBPMarginUnit1, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit1, VBPMarginUnit1, VBPMarginUnit1, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit1, VBPMarginUnit1, VBPMarginUnit1, VBPMarginUnit1);
                MenuMargin = new Thickness(0, VBPMarginUnit1, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin1);
            }
            else if (w < VisualBreakPointWidth2)
            {
                GridView().RefreshLayout(VBPDesiredWidth2);
                ImageHeight = VBPImageHeight2;
                ImageWidth = VBPImageWidth2;
                ItemHeight = VBPItemHeight2;
                TitleMaxLines = VBPTitleMaxLines2;
                TitleFontSize = VBPTitleFontSize2;
                SubTitleFontSize = VBPSubTitleFontSize2;
                LeftMarginTitle = new Thickness(VBPMarginUnit2, -6, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit2, VBPMarginUnit2, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit2, VBPMarginUnit2, VBPMarginUnit2, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit2, VBPMarginUnit2, VBPMarginUnit2, VBPMarginUnit2);
                MenuMargin = new Thickness(0, VBPMarginUnit2, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin2);
            }
            else if (w < VisualBreakPointWidth3)
            {
                GridView().RefreshLayout(VBPDesiredWidth3);
                ImageHeight = VBPImageHeight3;
                ImageWidth = VBPImageWidth3;
                ItemHeight = VBPItemHeight3;
                TitleMaxLines = VBPTitleMaxLines3;
                TitleFontSize = VBPTitleFontSize3;
                SubTitleFontSize = VBPSubTitleFontSize3;
                LeftMarginTitle = new Thickness(VBPMarginUnit3, -6, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit3, VBPMarginUnit3, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit3, VBPMarginUnit3, VBPMarginUnit3, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit3, VBPMarginUnit3, VBPMarginUnit3, VBPMarginUnit3);
                MenuMargin = new Thickness(0, VBPMarginUnit3, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin3);
            }
            else if (w < VisualBreakPointWidth4)
            {
                GridView().RefreshLayout(VBPDesiredWidth4);
                ImageHeight = VBPImageHeight4;
                ImageWidth = VBPImageWidth4;
                ItemHeight = VBPItemHeight4;
                TitleMaxLines = VBPTitleMaxLines4;
                TitleFontSize = VBPTitleFontSize4;
                SubTitleFontSize = VBPSubTitleFontSize4;
                LeftMarginTitle = new Thickness(VBPMarginUnit4, -6, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit4, VBPMarginUnit4, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit4, VBPMarginUnit4, VBPMarginUnit4, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit4, VBPMarginUnit4, VBPMarginUnit4, VBPMarginUnit4);
                MenuMargin = new Thickness(0, VBPMarginUnit4, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin4);
            }
            else
            {
                GridView().RefreshLayout(VBPDesiredWidth5);
                ImageHeight = VBPImageHeight5;
                ImageWidth = VBPImageWidth5;
                ItemHeight = VBPItemHeight5;
                TitleMaxLines = VBPTitleMaxLines5;
                TitleFontSize = VBPTitleFontSize5;
                SubTitleFontSize = VBPSubTitleFontSize5;
                LeftMarginTitle = new Thickness(VBPMarginUnit5, -6, 0, 0);
                LeftMarginSubTitle = new Thickness(VBPMarginUnit5, VBPMarginUnit5, 0, 0);
                BoxLeftMarginTitle = new Thickness(VBPMarginUnit5, VBPMarginUnit5, VBPMarginUnit5, 0);
                BoxLeftMarginSubTitle = new Thickness(VBPMarginUnit5, VBPMarginUnit5, VBPMarginUnit5, VBPMarginUnit5);
                MenuMargin = new Thickness(0, VBPMarginUnit5, 0, 0);
                ItemMargin = new Thickness(VBPItemMargin5);
            }
            if (OneRowModeEnabled)
            {
                GridView().MaxHeight = ItemHeight;
            }
        }

        private void UCLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (OneRowModeEnabled)
            {
                GridView().VerticalScroll = ScrollMode.Disabled;
            }
            RefreshLayout();
        }
        private void UCSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RefreshLayout();
        }
    }
}
