using System;
using System.Collections.Generic;

namespace LMS.Core.Data
{
    public partial class Card
    {
        public decimal Cardid { get; set; }
        public long? CardNumber { get; set; }
        public byte? CardCvv { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? CardholderName { get; set; }
        public decimal? Balance { get; set; }
    }
}
