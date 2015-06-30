using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutBigHorizontalCardBox : LargeSizeListLayout
    {
        public ListLayoutBigHorizontalCardBox() : base()
        {
            this.InitializeComponent();
        }

        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }
    }
}
