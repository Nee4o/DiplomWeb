using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Histories = new HashSet<History>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Cabinet { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
