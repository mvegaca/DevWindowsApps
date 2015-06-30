using System;
using AppStudio.DataProviders;

namespace TheRollingStones.Sections
{
    /// <summary>
    /// Implementation of the BestAlbums1Schema class.
    /// </summary>
    public class BestAlbums1Schema : SchemaBase
    {

        public string Name { get; set; }

        public string Year { get; set; }

        public string Summary { get; set; }

        public string Cover { get; set; }

        public string TrackList { get; set; }

        public string Url { get; set; }
    }
}
