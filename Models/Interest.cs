using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Interest
    {
        public int InterestId { get; set; }
        public string? InterestName { get; set; }
        public string? CandidateId { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
