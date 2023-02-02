using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DiplomWeb.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Post { get; set; } = null!;
        public string? Description { get; set; }
        public int IdType { get; set; }
        public int IdStatus { get; set; }

        [JsonIgnore]
        public DateOnly DateOfCreation { get; set; }

        public int IdWorker { get; set; }

        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual Type IdTypeNavigation { get; set; } = null!;
        public virtual Worker IdWorkerNavigation { get; set; } = null!;
    }
}
