using Windows.UI.Xaml;

namespace TheRollingStones.Layouts
{
    public abstract class LargeSizeListLayout : BaseListLayout
    {
        public LargeSizeListLayout() : base()
        {
        }

        protected override double VBPDesiredWidth0 { get { return 300; } }
        protected override double VBPImageHeight0 { get { return 0; } }
        protected override double VBPImageWidth0 { get { return 126; } }
        protected override double VBPItemHeight0 { get { return 140; } }
        protected override int VBPTitleMaxLines0 { get { return 3; } }
        protected override double VBPTitleFontSize0 { get { return (double)Application.Current.Resources["ListTitleTextVeryLowResolutions"]; } }
        protected override double VBPSubTitleFontSize0 { get { return (double)Application.Current.Resources["ListSubTitleTextVeryLowResolutions"]; } }
        protected override double VBPMarginUnit0 { get { return 6; } }
        protected override double VBPItemMargin0 { get { return 2; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VisualBreakPointWidth0 { get { return 321; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VBPDesiredWidth1 { get { return 300; } }
        protected override double VBPImageHeight1 { get { return 0; } }
        protected override double VBPImageWidth1 { get { return 200; } }
        protected override double VBPItemHeight1 { get { return 200; } }
        protected override int VBPTitleMaxLines1 { get { return 4; } }
        protected override double VBPTitleFontSize1 { get { return (double)Application.Current.Resources["ListTitleTextLowResolutions"]; } }
        protected override double VBPSubTitleFontSize1 { get { return (double)Application.Current.Resources["ListSubTitleTextLowResolutions"]; } }
        protected override double VBPMarginUnit1 { get { return 10; } }
        protected override double VBPItemMargin1 { get { return 4; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VisualBreakPointWidth1 { get { return 500; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VBPDesiredWidth2 { get { return 330; } }
        protected override double VBPImageHeight2 { get { return 0; } }
        protected override double VBPImageWidth2 { get { return 200; } }
        protected override double VBPItemHeight2 { get { return 200; } }
        protected override int VBPTitleMaxLines2 { get { return 5; } }
        protected override double VBPTitleFontSize2 { get { return (double)Application.Current.Resources["ListTitleTextLowResolutions"]; } }
        protected override double VBPSubTitleFontSize2 { get { return (double)Application.Current.Resources["ListSubTitleTextLowResolutions"]; } }
        protected override double VBPMarginUnit2 { get { return 12; } }
        protected override double VBPItemMargin2 { get { return 6; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VisualBreakPointWidth2 { get { return 900; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VBPDesiredWidth3 { get { return 400; } }
        protected override double VBPImageHeight3 { get { return 0; } }
        protected override double VBPImageWidth3 { get { return 250; } }
        protected override double VBPItemHeight3 { get { return 250; } }
        protected override int VBPTitleMaxLines3 { get { return 5; } }
        protected override double VBPTitleFontSize3 { get { return (double)Application.Current.Resources["ListTitleTextMediumResolutions"]; } }
        protected override double VBPSubTitleFontSize3 { get { return (double)Application.Current.Resources["ListSubTitleTextMediumResolutions"]; } }
        protected override double VBPMarginUnit3 { get { return 16; } }
        protected override double VBPItemMargin3 { get { return 10; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VisualBreakPointWidth3 { get { return 1140; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VBPDesiredWidth4 { get { return 550; } }
        protected override double VBPImageHeight4 { get { return 0; } }
        protected override double VBPImageWidth4 { get { return 300; } }
        protected override double VBPItemHeight4 { get { return 300; } }
        protected override int VBPTitleMaxLines4 { get { return 5; } }
        protected override double VBPTitleFontSize4 { get { return (double)Application.Current.Resources["ListTitleTextHighResolutions"]; } }
        protected override double VBPSubTitleFontSize4 { get { return (double)Application.Current.Resources["ListSubTitleTextHighResolutions"]; } }
        protected override double VBPMarginUnit4 { get { return 16; } }
        protected override double VBPItemMargin4 { get { return 10; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VisualBreakPointWidth4 { get { return 1650; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        protected override double VBPDesiredWidth5 { get { return 700; } }
        protected override double VBPImageHeight5 { get { return 0; } }
        protected override double VBPImageWidth5 { get { return 350; } }
        protected override double VBPItemHeight5 { get { return 350; } }
        protected override int VBPTitleMaxLines5 { get { return 6; } }
        protected override double VBPTitleFontSize5 { get { return (double)Application.Current.Resources["ListTitleTextHighResolutions"]; } }
        protected override double VBPSubTitleFontSize5 { get { return (double)Application.Current.Resources["ListSubTitleTextHighResolutions"]; } }
        protected override double VBPMarginUnit5 { get { return 16; } }
        protected override double VBPItemMargin5 { get { return 10; } }
        //------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
