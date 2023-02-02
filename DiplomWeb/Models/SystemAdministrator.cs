using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class SystemAdministrator
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int IdJobName { get; set; }

        public virtual JobName IdJobNameNavigation { get; set; } = null!;
    }
}
