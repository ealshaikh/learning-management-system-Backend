using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Certificates = new HashSet<Certificate>();
            Orders = new HashSet<Order>();
            Studentassessments = new HashSet<Studentassessment>();
            Usercourses = new HashSet<Usercourse>();
            Usersections = new HashSet<Usersection>();
        }

        public decimal Studentid { get; set; }
        public string? Studentfname { get; set; }
        public string? Studentlname { get; set; }
        public string? Phoneno { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Profileimage { get; set; }

        public virtual Studentenrollment? Studentenrollment { get; set; }
        public virtual Studentuserlogin? Studentuserlogin { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Studentassessment> Studentassessments { get; set; }
        public virtual ICollection<Usercourse> Usercourses { get; set; }
        public virtual ICollection<Usersection> Usersections { get; set; }
    }
}
