using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using TheRollingStones.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TheRollingStones.Layouts.Controls
{
    public sealed partial class CarouselLayout : UserControl
    {
        #region Properties
        private double _desiredWidth;
        private int _columns;
        DispatcherTimer dt = new DispatcherTimer();
        #region ItemWidth
        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(CarouselLayout), new PropertyMetadata(0D, OnItemsWidthPropertyChange));
        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }
        private static void OnItemsWidthPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = d as CarouselLayout;

            self.ItemWidth = (Double)e.NewValue;

            //initialize
            if (self._desiredWidth == 0)
            {
                self._desiredWidth = self.ItemWidth;
            }
        }
        #endregion
        #region ItemWidth
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(CarouselLayout), new PropertyMetadata(0D));
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); InitializeFlipViewHeight(); }
        }
        #endregion
        #region RowsInFlip
        public static readonly DependencyProperty RowsInFlipProperty =
            DependencyProperty.Register("RowsInFlip", typeof(int), typeof(CarouselLayout), new PropertyMetadata(1));
        public int RowsInFlip
        {
            get { return (int)GetValue(RowsInFlipProperty); }
            set { SetValue(RowsInFlipProperty, value); InitializeFlipViewHeight(); }
        }
        #endregion
        #region ItemTemplate
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(CarouselLayout), new PropertyMetadata(null));
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        #endregion
        #region ItemClickCommand
        public static readonly DependencyProperty ItemClickCommandProperty =
                DependencyProperty.Register("ItemClickCommand", typeof(ICommand), typeof(CarouselLayout), new PropertyMetadata(null, OnItemClickCommandPropertyChange));

        public ICommand ItemClickCommand
        {
            get { return (ICommand)GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }
        private static void OnItemClickCommandPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = d as CarouselLayout;
            self.ItemClickCommand = e.NewValue as ICommand;
        }
        #endregion
        #region ItemsSource
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<ItemViewModel>), typeof(CarouselLayout), new PropertyMetadata(null, OnItemsSourcePropertyChange));
        public ObservableCollection<ItemViewModel> ItemsSource
        {
            get { return (ObservableCollection<ItemViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); UpdateFlipViewData(); }
        }

        int lastUpdateItemSourceCount = 0;
        int itemsOnFlipItem = 0;
        private void UpdateFlipViewData(bool forceUpdate = false)
        {
            if (ItemsSource == null || ItemsSource.Count == 0) return;
            if (ItemsSource.Count == lastUpdateItemSourceCount)
            {
                dt.Stop();
                if (forceUpdate == false) return;
            }
            if (itemsOnFlipItem == 0)
            {
                //Initialize
                //itemsOnFlipItem = ((int)flipView.ActualWidth / (int)ItemWidth) * RowsInFlip;
                itemsOnFlipItem = ((int)Window.Current.Bounds.Width / (int)ItemWidth) * RowsInFlip;
            }
            double result = (double)ItemsSource.Count / itemsOnFlipItem;
            if (result > Math.Truncate(result))
            {
                result++;
            }
            int flipNumber = (int)result;
            FlipViewItems.Clear();
            for (int i = 0; i < flipNumber; i++)
            {
                ObservableCollection<ItemViewModel> flipFlement = new ObservableCollection<ItemViewModel>();
                for (int j = 0; j < itemsOnFlipItem; j++)
                {
                    int processingItem = (i * itemsOnFlipItem) + j;
                    if (ItemsSource.Count > processingItem)
                    {
                        flipFlement.Add(ItemsSource[processingItem]);
                    }
                }
                FlipViewItems.Add(flipFlement);
            }
            lastUpdateItemSourceCount = ItemsSource.Count;
        }

        private static void OnItemsSourcePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = d as CarouselLayout;
            self.ItemsSource = e.NewValue as ObservableCollection<ItemViewModel>;
        }
        #endregion
        #region FlipViewItems
        private ObservableCollection<ObservableCollection<ItemViewModel>> _flipViewItems;
        public ObservableCollection<ObservableCollection<ItemViewModel>> FlipViewItems
        {
            get
            {
                if (_flipViewItems == null)
                {
                    _flipViewItems = new ObservableCollection<ObservableCollection<ItemViewModel>>();
                }
                return _flipViewItems;
            }
            private set
            {
                _flipViewItems = value;
            }
        }
        #endregion
        #endregion

        private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.PreviousSize.Width != e.NewSize.Width)
            {
                //initialize 
                if (_columns == 0 || itemsOnFlipItem == 0)
                {
                    _columns = CalculateColumns(gridView.ActualWidth, ItemWidth);
                    itemsOnFlipItem = _columns;
                }
                else
                {
                    var desiredColumns = CalculateColumns(gridView.ActualWidth, _desiredWidth);
                    if (desiredColumns != _columns)
                    {
                        //Colum number changes
                        _columns = desiredColumns;
                        itemsOnFlipItem = _columns * RowsInFlip;
                        UpdateFlipViewData(true);
                    }
                }
                ItemWidth = (e.NewSize.Width / _columns) - 5;
            }
        }
        private static int CalculateColumns(double containerWidth, double itemWidth)
        {
            var columns = (int)(containerWidth / itemWidth);
            if (columns == 0)
            {
                columns = 1;
            }
            return columns;
        }
        private void InitializeFlipViewHeight()
        {
            int margin = 8;
            flipView.Height = (RowsInFlip * ItemHeight) + margin;
        }

        public CarouselLayout()
        {
            this.InitializeComponent();
            dt.Tick += ((sender, e) => { UpdateFlipViewData(); });
            dt.Start();
        }
    }
}