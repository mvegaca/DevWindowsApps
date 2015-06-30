using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutBigVerticalCard : MediumSizeListLayout
    {
        public ListLayoutBigVerticalCard() : base()
        {
            this.InitializeComponent();
        }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
