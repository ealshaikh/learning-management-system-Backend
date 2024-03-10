using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Order
    {
        public decimal Orderid { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Planid { get; set; }
        public DateTime? Orderdate { get; set; }
        public decimal? Totalprice { get; set; }
        public string? Status { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual Student? Student { get; set; }
    }
}
