using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Industry
    {
        public Industry()
        {
            Companies = new HashSet<Company>();
        }

        public int IndustryId { get; set; }
        public string? IndustryName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
