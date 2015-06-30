using System;
using AppStudio.DataProviders;

namespace TheRollingStones.Sections
{
    /// <summary>
    /// Implementation of the XboxMusic1Schema class.
    /// </summary>
    public class XboxMusic1Schema : SchemaBase
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ReleaseDate { get; set; }

        public string LabelName { get; set; }

        public string Genre { get; set; }

        public string Link { get; set; }
    }
}
