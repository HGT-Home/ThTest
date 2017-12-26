using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Th.Configuration
{
    public class ThConfiguration
    {
        public IList<ThCulture> Cultures
        {
            get;
            set;
        }

        public ThStaticFilesHeaders StaticFilesHeaders { get; set; } = new ThStaticFilesHeaders();

        public ThConfiguration()
        {
            this.Cultures = new List<ThCulture>();
        }
    }
}
