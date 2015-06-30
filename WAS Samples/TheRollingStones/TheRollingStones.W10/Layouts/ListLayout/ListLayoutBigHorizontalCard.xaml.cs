using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutBigHorizontalCard : LargeSizeListLayout
    {
        public ListLayoutBigHorizontalCard() : base()
        {
            this.InitializeComponent();
        }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
