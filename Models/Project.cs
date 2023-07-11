using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string? CandidateId { get; set; }
        public string? ProjectName { get; set; }
        public int? NumberMember { get; set; }
        public string? Position { get; set; }
        public string? Mission { get; set; }
        public string? Technology { get; set; }
        public int? StartMonth { get; set; }
        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }
        public int? StartYear { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
