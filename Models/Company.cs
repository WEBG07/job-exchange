using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Company
    {
        public Company()
        {
            Recruitments = new HashSet<Recruitment>();
        }

        public string CompanyId { get; set; } = null!;
        public string? AccountId { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public int? IndustryId { get; set; }
        public string? Introduce { get; set; }
        public string? Scale { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public string? CoverImage { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Industry? Industry { get; set; }
        public virtual ICollection<Recruitment> Recruitments { get; set; }
    }
}
