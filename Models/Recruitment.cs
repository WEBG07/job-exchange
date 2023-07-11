using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Recruitment
    {
        public Recruitment()
        {
            CandidateRecruitments = new HashSet<CandidateRecruitment>();
            SaveRecruitments = new HashSet<SaveRecruitment>();
        }

        public string RecruitmentId { get; set; } = null!;
        public string? CompanyId { get; set; }
        public int? Salary { get; set; }
        public string? WorkType { get; set; }
        public string? GenderRequirement { get; set; }
        public int? HiringCount { get; set; }
        public string? PositionLevel { get; set; }
        public int? Experience { get; set; }
        public string? WorkLocation { get; set; }
        public string? JobDescription { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CandidateRequirement { get; set; }
        public string? Benefits { get; set; }
        public string? Status { get; set; }
        public string? Slug { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<CandidateRecruitment> CandidateRecruitments { get; set; }
        public virtual ICollection<SaveRecruitment> SaveRecruitments { get; set; }
    }
}
