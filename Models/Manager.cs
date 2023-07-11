using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Manager
    {
        public string ManagerId { get; set; } = null!;
        public string? AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }

        public virtual Account? Account { get; set; }
    }
}
