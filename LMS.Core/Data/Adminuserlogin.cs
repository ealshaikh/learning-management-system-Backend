using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Adminuserlogin
    {
        public decimal Adminuserloginid { get; set; }
        public decimal? Adminid { get; set; }
        public decimal? Roleid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
    }
}
