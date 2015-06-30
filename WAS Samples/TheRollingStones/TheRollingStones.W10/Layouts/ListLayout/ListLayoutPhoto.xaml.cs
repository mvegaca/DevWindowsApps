using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutPhoto : MediumSizeListLayout
    {
        public ListLayoutPhoto() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPItemHeight0 { get { return 120; } }
        protected override double VBPItemHeight1 { get { return 150; } }
        protected override double VBPItemHeight2 { get { return 220; } }
        protected override double VBPItemHeight3 { get { return 280; } }
        protected override double VBPItemHeight4 { get { return 360; } }
        protected override double VBPItemHeight5 { get { return 450; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
