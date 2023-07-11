using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Experience
    {
        public int ExperienceId { get; set; }
        public string? CompanyName { get; set; }
        public string? Position { get; set; }
        public int? StartMonth { get; set; }
        public int? StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? CandidateId { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
