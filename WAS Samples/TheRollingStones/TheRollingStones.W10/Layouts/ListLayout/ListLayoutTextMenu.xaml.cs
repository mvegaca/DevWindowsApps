using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutTextMenu : MediumSizeListLayout
    {
        public ListLayoutTextMenu() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPItemHeight0 { get { return 30; } }
        protected override double VBPItemHeight1 { get { return 40; } }
        protected override double VBPItemHeight2 { get { return 50; } }
        protected override double VBPItemHeight3 { get { return 70; } }
        protected override double VBPItemHeight4 { get { return 100; } }
        protected override double VBPItemHeight5 { get { return 120; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
