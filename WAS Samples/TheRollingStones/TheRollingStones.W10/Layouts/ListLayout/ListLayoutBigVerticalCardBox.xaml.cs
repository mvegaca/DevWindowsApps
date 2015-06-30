using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutBigVerticalCardBox : MediumSizeListLayout
    {
        public ListLayoutBigVerticalCardBox() : base()
        {
            this.InitializeComponent();
        }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
