using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Teacher
    {
        public decimal Teacherid { get; set; }
        public string? Teacherfname { get; set; }
        public string? Teacherlname { get; set; }
        public string? Phoneno { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Profileimage { get; set; }

        public virtual Section? Section { get; set; }
        public virtual Teacheruserlogin? Teacheruserlogin { get; set; }
    }
}
