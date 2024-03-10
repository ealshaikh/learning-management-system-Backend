using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Usercourse
    {
        public decimal Usercourseid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Examid { get; set; }
        public decimal? Studentgrade { get; set; }
        public string? Status { get; set; }

        public virtual Exam? Exam { get; set; }
        public virtual Student? Student { get; set; }
    }
}
