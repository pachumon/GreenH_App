using System;
using System.Collections.Generic;

namespace GreenwayCoding.Models
{
    public class BillingInfo
    {
        public double BillTotal { get; set; }
        public bool HasErrors { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
