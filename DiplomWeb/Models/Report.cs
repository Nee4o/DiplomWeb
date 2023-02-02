using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public string Period { get; set; } = null!;
        public decimal Costs { get; set; }
    }
}
