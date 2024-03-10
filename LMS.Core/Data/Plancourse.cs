using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Plancourse
    {
        public decimal Plancourseid { get; set; }
        public decimal? Planid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Ordernumber { get; set; }

        public virtual Plan? Plan { get; set; }
    }
}
