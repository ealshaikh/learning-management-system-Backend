using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Adminuserlogins = new HashSet<Adminuserlogin>();
            Studentuserlogins = new HashSet<Studentuserlogin>();
            Teacheruserlogins = new HashSet<Teacheruserlogin>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Adminuserlogin> Adminuserlogins { get; set; }
        public virtual ICollection<Studentuserlogin> Studentuserlogins { get; set; }
        public virtual ICollection<Teacheruserlogin> Teacheruserlogins { get; set; }
    }
}
