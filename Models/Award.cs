using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Award
    {
        public string AwardId { get; set; } = null!;
        public string? CandidateId { get; set; }
        public string? AwardName { get; set; }
        public string? Organization { get; set; }
        public int? ReceivedMonth { get; set; }
        public int? ReceivedYear { get; set; }
        public string? Image { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
