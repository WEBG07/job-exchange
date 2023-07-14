using JobExchange.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExchange.Models
{
    public partial class Recruitment
    {
        [Key]
        public string RecruitmentId { get; set; } = null!;
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
        public string CompanyId { get; set; } = null!;

        [ForeignKey("CompanyId")]
        public Company Company { get; set; } = null!;
    }
}
