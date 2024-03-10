using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Teacheruserlogin
    {
        public decimal Teacheruserloginid { get; set; }
        public decimal? Teacherid { get; set; }
        public decimal? Roleid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
