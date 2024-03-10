using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Attendance
    {
        public decimal Attendanceid { get; set; }
        public DateTime? Attendancedate { get; set; }
        public decimal? Sectionid { get; set; }
        public decimal? Studentid { get; set; }
        public string? Status { get; set; }

        public virtual Section? Section { get; set; }
        public virtual Student? Student { get; set; }
    }
}
