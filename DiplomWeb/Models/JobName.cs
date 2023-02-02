using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class JobName
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual SystemAdministrator? SystemAdministrator { get; set; }
    }
}
