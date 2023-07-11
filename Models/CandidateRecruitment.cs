using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class CandidateRecruitment
    {
        public string RecruitmentId { get; set; } = null!;
        public string CandidateId { get; set; } = null!;
        public string? UrlCv { get; set; }
        public string? ApplicationStatus { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Candidate Candidate { get; set; } = null!;
        public virtual Recruitment Recruitment { get; set; } = null!;
    }
}
