using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int IdWorker { get; set; }

        public virtual Worker IdWorkerNavigation { get; set; } = null!;
    }
}
