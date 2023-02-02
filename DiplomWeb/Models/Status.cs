using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class Status
    {
        public Status()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
