using System;
using System.Collections.Generic;

namespace JobExchange.Models
{
    public partial class Skill
    {
        public int SkillId { get; set; }
        public string? CandidateId { get; set; }
        public string? SkillName { get; set; }
        public string? Description { get; set; }

        public virtual Candidate? Candidate { get; set; }
    }
}
