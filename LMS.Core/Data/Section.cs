using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Section
    {
        public Section()
        {
            Attendances = new HashSet<Attendance>();
            Coursesections = new HashSet<Coursesection>();
            Usersections = new HashSet<Usersection>();
        }

        public decimal Sectionid { get; set; }
        public decimal? Sectionno { get; set; }
        public string? Sectionname { get; set; }
        public string? Sectionstatus { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string? Material { get; set; }
        public decimal? Sectioncapacity { get; set; }
        public string? SectionlecLink { get; set; }
        public decimal? Planid { get; set; }
        public decimal? Courseid { get; set; }
        public decimal? Teacherid { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Coursesection> Coursesections { get; set; }
        public virtual ICollection<Usersection> Usersections { get; set; }
    }
}
