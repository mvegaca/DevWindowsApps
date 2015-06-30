using AppStudio.Common.Controls;

namespace TheRollingStones.Layouts
{
    public sealed partial class ListLayoutBigMenu : MediumSizeListLayout
    {
        public ListLayoutBigMenu() : base()
        {
            this.InitializeComponent();
        }
        protected override ResponsiveGridView GridView()
        {
            return responsiveGridView;
        }

    }
}
