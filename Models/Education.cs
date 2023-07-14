using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobExchange.Models
{
    public partial class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducationId { get; set; }
        public string? SchoolName { get; set; }
        public string? Major { get; set; }
        public int? StartMonth { get; set; }
        public int? StartYear { get; set; }
        public int? EndMonth { get; set; }
        public int? EndYear { get; set; }
        public string? Description { get; set; }
        public string CandidateId { get; set; } = null!;

        [ForeignKey("CandidateId")]
        [ValidateNever]
        public Candidate Candidate { get; set; } = null!;
    }
}
