using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Certification
    {
        public int CertificationId { get; set; }
        public string? CandidateId { get; set; }
        public string? CertificationName { get; set; }
        public string? Organization { get; set; }
        public int? ReceivedMonth { get; set; }
        public int? ReceivedYear { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
        public string? Image { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
