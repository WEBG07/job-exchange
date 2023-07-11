using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class SaveRecruitment
    {
        public string RecruitmentId { get; set; } = null!;
        public string CandidateId { get; set; } = null!;
        public DateTime? CreateDate { get; set; }

        public virtual Candidate Candidate { get; set; } = null!;
        public virtual Recruitment Recruitment { get; set; } = null!;
    }
}
