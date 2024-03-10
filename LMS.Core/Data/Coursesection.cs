using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Coursesection
    {
        public decimal Coursesectionid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Sectionid { get; set; }

        public virtual Section? Section { get; set; }
    }
}
