
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobExchange.Models
{
    public partial class Candidate
    {
        public Candidate()
        {
            Awards = new HashSet<Award>();
            CandidateRecruitments = new HashSet<CandidateRecruitment>();
            Certifications = new HashSet<Certification>();
            Educations = new HashSet<Education>();
            Experiences = new HashSet<Experience>();
            Interests = new HashSet<Interest>();
            Projects = new HashSet<Project>();
            SaveRecruitments = new HashSet<SaveRecruitment>();
            Skills = new HashSet<Skill>();
        }

        public string CandidateId { get; set; } = null!;
        public string? AccountId { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Avatar { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<CandidateRecruitment> CandidateRecruitments { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<SaveRecruitment> SaveRecruitments { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
