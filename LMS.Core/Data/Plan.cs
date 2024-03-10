using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Plan
    {
        public Plan()
        {
            Certificates = new HashSet<Certificate>();
            Orders = new HashSet<Order>();
            Plancourses = new HashSet<Plancourse>();
            Sections = new HashSet<Section>();
            Studentenrollments = new HashSet<Studentenrollment>();
        }

        public decimal Planid { get; set; }
        public string? Planname { get; set; }
        public string? Plandescription { get; set; }
        public string? Coverimage { get; set; }
        public decimal? Planprice { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Plancourse> Plancourses { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<Studentenrollment> Studentenrollments { get; set; }
    }
}
