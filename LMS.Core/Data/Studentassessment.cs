using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Studentassessment
    {
        public decimal Studentassessmentid { get; set; }
        public string? Status { get; set; }
        public string? Comment { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Student? Student { get; set; }
    }
}
