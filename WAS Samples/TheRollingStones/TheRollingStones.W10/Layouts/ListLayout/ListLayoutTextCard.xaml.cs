using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutTextCard : MediumSizeListLayout
    {
        public ListLayoutTextCard() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPItemHeight0 { get { return 130; } }
        protected override double VBPItemHeight1 { get { return 180; } }
        protected override double VBPItemHeight2 { get { return 180; } }
        protected override double VBPItemHeight3 { get { return 220; } }
        protected override double VBPItemHeight4 { get { return 280; } }
        protected override double VBPItemHeight5 { get { return 320; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
