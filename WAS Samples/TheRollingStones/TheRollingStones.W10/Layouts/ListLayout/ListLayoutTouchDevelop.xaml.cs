using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutTouchDevelop : LargeSizeListLayout
    {
        public ListLayoutTouchDevelop() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPItemHeight0 { get { return double.NaN; } }
        protected override double VBPItemHeight1 { get { return double.NaN; } }
        protected override double VBPItemHeight2 { get { return double.NaN; } }
        protected override double VBPItemHeight3 { get { return double.NaN; } }
        protected override double VBPItemHeight4 { get { return double.NaN; } }
        protected override double VBPItemHeight5 { get { return double.NaN; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
