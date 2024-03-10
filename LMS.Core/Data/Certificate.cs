using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Certificate
    {
        public decimal Certificateid { get; set; }
        public DateTime? Certificatedate { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Planid { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual Student? Student { get; set; }
    }
}
