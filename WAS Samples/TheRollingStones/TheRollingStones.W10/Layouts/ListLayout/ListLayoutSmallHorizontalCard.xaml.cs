using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutSmallHorizontalCard : MediumSizeListLayout
    {
        public ListLayoutSmallHorizontalCard() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPItemHeight0 { get { return 90; } }
        protected override double VBPItemHeight1 { get { return 116; } }
        protected override double VBPItemHeight2 { get { return 120; } }
        protected override double VBPItemHeight3 { get { return 130; } }
        protected override double VBPItemHeight4 { get { return 140; } }
        protected override double VBPItemHeight5 { get { return 160; } }

        protected override double VBPImageWidth0 { get { return 60; } }
        protected override double VBPImageWidth1 { get { return 80; } }
        protected override double VBPImageWidth2 { get { return 100; } }
        protected override double VBPImageWidth3 { get { return 120; } }
        protected override double VBPImageWidth4 { get { return 150; } }
        protected override double VBPImageWidth5 { get { return 200; } }

        protected override int VBPTitleMaxLines0 { get { return 2; } }
        protected override int VBPTitleMaxLines1 { get { return 2; } }
        protected override int VBPTitleMaxLines2 { get { return 2; } }
        protected override int VBPTitleMaxLines3 { get { return 2; } }
        protected override int VBPTitleMaxLines4 { get { return 2; } }
        protected override int VBPTitleMaxLines5 { get { return 2; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }

    }
}
