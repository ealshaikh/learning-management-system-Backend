using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Contact
    {
        public decimal ContactId { get; set; }
        public string? Messeage { get; set; }
        public string? Email { get; set; }
        public string? Fullname { get; set; }
    }
}
