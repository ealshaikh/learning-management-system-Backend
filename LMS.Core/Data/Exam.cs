using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Exam
    {
        public Exam()
        {
            Usercourses = new HashSet<Usercourse>();
        }

        public decimal Examid { get; set; }
        public DateTime? Examdate { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string? Mark { get; set; }
        public string? Subject { get; set; }
        public decimal? Courseid { get; set; }

        public virtual ICollection<Usercourse> Usercourses { get; set; }
    }
}
