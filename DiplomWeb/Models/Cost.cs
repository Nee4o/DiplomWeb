using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class Cost
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Amount { get; set; }
        public decimal Price { get; set; }
        public DateOnly Date { get; set; }
    }
}
