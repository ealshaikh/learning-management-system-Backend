using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Usersection
    {
        public decimal Usersectionid { get; set; }
        public decimal? Sectionid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Section? Section { get; set; }
        public virtual Student? Student { get; set; }
    }
}
