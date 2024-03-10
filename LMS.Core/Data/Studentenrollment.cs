using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Studentenrollment
    {
        public decimal Enrollmentid { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Planid { get; set; }
        public DateTime? Enrollmentdate { get; set; }
        public string? Approvalstatus { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual Student? Student { get; set; }
    }
}
