using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Account
    {
        public Account()
        {
            Candidates = new HashSet<Candidate>();
            Companies = new HashSet<Company>();
            Managers = new HashSet<Manager>();
        }

        public string AccountId { get; set; } = null!;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
