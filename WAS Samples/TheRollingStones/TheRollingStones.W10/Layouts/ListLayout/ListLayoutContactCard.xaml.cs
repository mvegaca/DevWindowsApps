using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutContactCard : LargeSizeListLayout
    {
        public ListLayoutContactCard() : base()
        {
            this.InitializeComponent();
        }

        protected override double VBPImageHeight0 { get { return 100; } }
        protected override double VBPImageWidth0 { get { return 100; } }
        protected override double VBPImageHeight1 { get { return 150; } }
        protected override double VBPImageWidth1 { get { return 150; } }
        protected override double VBPImageHeight2 { get { return 150; } }
        protected override double VBPImageWidth2 { get { return 150; } }
        protected override double VBPImageHeight3 { get { return 180; } }
        protected override double VBPImageWidth3 { get { return 180; } }
        protected override double VBPImageHeight4 { get { return 220; } }
        protected override double VBPImageWidth4 { get { return 220; } }
        protected override double VBPImageHeight5 { get { return 260; } }
        protected override double VBPImageWidth5 { get { return 260; } }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
