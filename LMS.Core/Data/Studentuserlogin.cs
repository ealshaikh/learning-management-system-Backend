using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Studentuserlogin
    {
        public decimal Studentuserloginid { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Roleid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Student? Student { get; set; }
    }
}
