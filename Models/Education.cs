using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Education
    {
        public int EducationId { get; set; }
        public string? SchoolName { get; set; }
        public string? Major { get; set; }
        public int? StartMonth { get; set; }
        public int? StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public string? Description { get; set; }
        public string? CandidateId { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
